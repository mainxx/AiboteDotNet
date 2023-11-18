using AiboteDotNet.Core.DataPacket;
using AiboteDotNet.Core.Session;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json.Linq;
using NLog.LayoutRenderers.Wrappers;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.Tcp
{
    public class TcpChannel
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        public virtual string RemoteAddress { get; set; } = "";
        public virtual Guid SessionId { get; set; }

        protected CancellationTokenSource closeSrc = new();
        public ConnectionContext Context { get; protected set; }
        protected PipeReader Reader { get; set; }
        protected PipeWriter Writer { get; set; }


        private readonly SemaphoreSlim sendSemaphore = new SemaphoreSlim(0);
        private readonly MemoryStream sendStream = new();

        protected Func<Session.Session, Task> onRun;
        protected BotOptions botOption;
        public TcpChannel(ConnectionContext context, BotOptions botOption, Func<Session.Session, Task> onRun)
        {
            this.onRun = onRun;
            this.botOption = botOption;
            Context = context;
            Reader = context.Transport.Input;
            Writer = context.Transport.Output;
            RemoteAddress = context.RemoteEndPoint?.ToString();
            SessionId = Guid.NewGuid();
        }
        public virtual bool IsClose()
        {
            return closeSrc.IsCancellationRequested;
        }
        public virtual void Close()
        {
            closeSrc.Cancel();
        }
        private Queue<Func<Task<byte[]>>> taskQueue = new Queue<Func<Task<byte[]>>>();
        private bool isProcessing = false;
        private object queueLock = new object();
        protected TaskCompletionSource<byte[]> _TCSReadMsg = null;
        private readonly int timeoutMilliseconds = 60000;
        // 设置超时时间为5秒（可以根据需要调整）
        //public async Task<byte[]> Write(byte[] bytes)
        //{
        //    if (IsClose())
        //    {
        //        return null;
        //    }
        //    if (_TCSReadMsg != null)
        //    {
        //        Guid guid = Guid.NewGuid();
        //        LOGGER.Debug($"开始等待：{guid}");
        //        // 等待上一个请求完成
        //        await _TCSReadMsg.Task;
        //        LOGGER.Debug($"等待结束：{guid}");
        //    }
        //    _TCSReadMsg = new();
        //    lock (sendStream)
        //    {
        //        sendStream.Write(bytes);
        //    }
        //    sendSemaphore.Release();
        //    LOGGER.Debug($"----[{RemoteAddress}]发送消息：{Encoding.UTF8.GetString(bytes).Replace("\n", "[\\n]")}");
        //    var completedTask = await Task.WhenAny(_TCSReadMsg.Task, Task.Delay(timeoutMilliseconds));
        //    if (completedTask == _TCSReadMsg.Task)
        //    {
        //        // 读取结果完成
        //        return _TCSReadMsg.Task.Result;
        //    }
        //    else
        //    {
        //        receivedBytes.Clear();
        //        // 使用 TrySetCanceled 表示任务被取消
        //        _TCSReadMsg.SetResult(null);
        //        // 超时
        //        LOGGER.Error($"等待读取结果超时。");
        //        return null;
        //    }
        //}
        private Queue<byte[]> messageQueue = new Queue<byte[]>();
        private List<TaskCompletionSource<byte[]>> messageResults = new List<TaskCompletionSource<byte[]>>();

        public async Task<byte[]> Write(byte[] bytes)
        {
            if (IsClose())
            {
                return null;
            }

            // 创建一个新的 TaskCompletionSource 用于等待结果
            var tcs = new TaskCompletionSource<byte[]>();

            lock (queueLock)
            {
                messageQueue.Enqueue(bytes);
                messageResults.Add(tcs);

                if (!isProcessing)
                {
                    isProcessing = true;
                    Task.Run(() => ProcessQueue());
                }
            }

            // 等待任务完成并返回结果
            return await tcs.Task;
        }

        private async Task ProcessQueue()
        {
            while (true)
            {
                byte[] messageToProcess = null;
                TaskCompletionSource<byte[]> tcsToComplete = null;

                lock (queueLock)
                {
                    if (messageQueue.Count > 0)
                    {
                        messageToProcess = messageQueue.Dequeue();
                        tcsToComplete = messageResults.FirstOrDefault();
                        if (tcsToComplete != null)
                        {
                            messageResults.Remove(tcsToComplete);
                        }
                        else
                        {
                            isProcessing = false;
                            break;
                        }
                    }
                    else
                    {
                        isProcessing = false;
                        break;
                    }
                }

                if (messageToProcess != null && tcsToComplete != null)
                {
                    byte[] result = await WriteImplementation(messageToProcess);
                    tcsToComplete.SetResult(result);
                }
            }
        }

        private async Task<byte[]> WriteImplementation(byte[] bytes)
        {
            if (IsClose())
            {
                return null;
            }
            if (_TCSReadMsg != null)
            {
                Guid guid = Guid.NewGuid();
                LOGGER.Debug($"开始等待：{guid}");
                // 等待上一个请求完成
                await _TCSReadMsg.Task;
                LOGGER.Debug($"等待结束：{guid}");
            }
            _TCSReadMsg = new();
            lock (sendStream)
            {
                sendStream.Write(bytes);
            }
            sendSemaphore.Release();
            LOGGER.Debug($"----[{RemoteAddress}]发送消息：{Encoding.UTF8.GetString(bytes).Replace("\n", "[\\n]")}");
            var completedTask = await Task.WhenAny(_TCSReadMsg.Task, Task.Delay(timeoutMilliseconds));
            if (completedTask == _TCSReadMsg.Task)
            {
                // 读取结果完成
                return _TCSReadMsg.Task.Result;
            }
            else
            {
                receivedBytes.Clear();
                // 使用 TrySetCanceled 表示任务被取消
                _TCSReadMsg.SetResult(null);
                // 超时
                LOGGER.Error($"等待读取结果超时。");
                return null;
            }
        }

        async Task TrySendAsync()
        {
            //pipewriter线程不安全，这里统一发送写刷新数据
#if !DEBUG
            try
            {
#endif
            var token = closeSrc.Token;
            while (!token.IsCancellationRequested)
            {
                await sendSemaphore.WaitAsync();
                lock (sendStream)
                {
                    var len = sendStream.Length;
                    if (len > 0)
                    {
                        Writer.Write(sendStream.GetBuffer().AsSpan<byte>()[..(int)len]);
                        sendStream.SetLength(0);
                        sendStream.Position = 0;
                    }
                    else
                    {
                        continue;
                    }
                }
                await Writer.FlushAsync(token);
            }
#if DEBUG
            try
            {
#endif
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }
        }

        protected virtual bool TryParseMessage(ref ReadOnlySequence<byte> input, out byte[] msg)
        {
            msg = null;
       
            if (receivedBytes.Count == 0)
            {
                return false; // 没有足够的数据来解析消息
            }
            if (_TCSReadMsg.Task.IsCompleted || _TCSReadMsg.Task.IsCanceled)
            {
                input = input.Slice(input.GetPosition(input.Length));
                return false;
            }
            LOGGER.Debug($"接收到客户端数据，长度：{input.Length}");
            int msgEndIndex = receivedBytes.IndexOf((byte)'/');
            if (msgEndIndex >= 0)
            {
                // 获取 '/' 之前的字节内容
                byte[] lengthBytes = receivedBytes.GetRange(0, msgEndIndex).ToArray();

                // 尝试将字节内容转换为 int
                if (int.TryParse(Encoding.UTF8.GetString(lengthBytes), out int expectedLength))
                {
                    // 判断字节长度是否一致
                    if (receivedBytes.Count == expectedLength + msgEndIndex + 1)
                    {
                        // 获取完整的消息，不包括 '/'
                        msg = receivedBytes.GetRange(msgEndIndex + 1, expectedLength).ToArray();
                        // 字节长度一致，表示找到了完整的消息
                        receivedBytes.Clear(); // 从接收的数据中移除已解析的部分
                        input = input.Slice(input.GetPosition(input.Length));
                        return true;
                    }
                }
                else
                {
                    // 字节内容无法解析为 int，表示格式不正确
                    LOGGER.Error("字节内容无法解析为 int，表示格式不正确");
                }
            }
            input = input.Slice(input.GetPosition(input.Length));
            return false; // 没有找到符合条件的消息
        }
        private List<byte> receivedBytes = new List<byte>();
        public async Task StartAsync()
        {
#if !DEBUG
            try
            {
#endif
            _ = TrySendAsync();

            //添加到session
            var session = new Session.Session { BotOption = botOption, Channel = this, Id = SessionId, Time = DateTime.Now };
            SessionManager.Add(session);
            LOGGER.Info($"----当前链接数：{SessionManager.Count()}");
            if (onRun != null)
            {
                _ = onRun(session);
            }
            var cancelToken = closeSrc.Token;
            while (!cancelToken.IsCancellationRequested)
            {
                var result = await Reader.ReadAsync(cancelToken);
                ReadOnlySequence<byte> buffer = result.Buffer;
                if (buffer.Length > 0)
                {
                    lock (receivedBytes)
                    {
                        foreach (var segment in buffer)
                        {
                            receivedBytes.AddRange(segment.ToArray());
                        }
                        while (TryParseMessage(ref buffer, out var outmsg))
                        {
                            if (_TCSReadMsg != null)
                            {
                                _TCSReadMsg.SetResult(outmsg);
                            }
                            else
                            {
                                LOGGER.Error("_TCSReadMsg==null");
                            }
                        }
                    }
                    Reader.AdvanceTo(buffer.Start, buffer.End);

                }
                else if (result.IsCanceled || result.IsCompleted)
                {
                    break;
                }
            }

#if DEBUG
            try
            {
#endif
            }
            catch (Exception e)
            {
                LOGGER.Error(e.Message);
            }
        }
    }
}
