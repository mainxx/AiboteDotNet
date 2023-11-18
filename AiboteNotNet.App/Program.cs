using AiboteDotNet.Core.Utils;
using AiboteNotNet.App.Common;
using NLog;
using NLog.Config;
using NLog.Fluent;
using System.Diagnostics;
using System.Text;

namespace AiboteNotNet.App
{
    internal class Program
    {
        private static volatile Task RunLoopTask = null;
        public static async Task Main(string[] args)
        {
            try
            {
                AppExitHandler.Init(HandleExit);
                RunLoopTask = AppStartUp.Enter();
                await RunLoopTask;
            }
            catch (Exception e)
            {
                string error;
                if (Settings.AppRunning)
                {
                    error = $"服务器运行时异常 e:{e}";
                    Console.WriteLine(error);
                }
                else
                {
                    error = $"启动服务器失败 e:{e}";
                    Console.WriteLine(error);
                }
                File.WriteAllText("server_error.txt", $"{error}", Encoding.UTF8);
            }
        }
        private static volatile bool ExitCalled = false;
        private static volatile Task ShutDownTask = null;
        private static void HandleExit()
        {
            if (ExitCalled)
                return;
            ExitCalled = true;
            Log.Info($"监听到退出程序消息");
            ShutDownTask = Task.Run(() =>
            {
                Settings.AppRunning = false;
                RunLoopTask?.Wait();
                LogManager.Shutdown();
                Console.WriteLine($"退出程序");
                Process.GetCurrentProcess().Kill();
            });
            ShutDownTask.Wait();
        }
    }
}