using AiboteDotNet.AndroidBot;
using AiboteDotNet.Core.Session;
using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteNotNet.App.AndroidLogic
{
    public class AndroidBotHandler : TcpConnectionHandler
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public override BotOptions CurBotOptions { get; set; } = BotOptions.AndroidBot;

        protected override async Task OnRun(TcpChannel channel, Session session)
        {
            IAndroidBot androidBot = new AndroidBot(channel);
            await Task.Delay(1000);
            await androidBot.InitOcr("192.168.2.105", 9527);
            await Task.Delay(1000);
            await androidBot.StartWeChatApp();
            await Task.Delay(3000);
            //滑动

            await Task.Delay(3000);
            if (await androidBot.GotoFaXian_Applet("能源谈事说"))
            {
                await Task.Delay(1000);

                await Task.Delay(6000);
                // 创建一个取消令牌源，用于在需要时停止定时器
                CancellationTokenSource cts = new CancellationTokenSource();

                int timeOutCount = 0;
                // 创建一个定时器，每1000毫秒（1秒）执行一次
                Timer timer = new Timer(async (_) =>
                {
                    try
                    {
                        LOGGER.Info("进入定时器");
                        var result = await androidBot.IsOpenWeChatApp();
                        if (result)
                        {

                            await Task.Delay(1000);
                            await CloseAppletPopup(androidBot);
                        }
                        else
                        {
                            timeOutCount++;
                            if (timeOutCount >= 5)
                            {
                                cts.Cancel();
                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        // 如果有异常，进行适当的处理
                        LOGGER.Error($"异常: {ex.Message}");
                    }
                }, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
                LOGGER.Info("执行异步线程");

                var openResult = await OpenWenZhang(androidBot);
                await Task.Delay(2000);
                if (openResult)
                {
                    await OpenJili(androidBot);
                }
                ////异步运行线程
                //_ = Task.Run(async () =>
                //{
                //    while (true)
                //    {
                //        // 在此运行后台操作
                //        // 模拟一个长时间运行的任务
                //        await Task.Delay(1000);
                //        LOGGER.Info("线程检查是否在微信");
                //        var result = await androidBot.IsOpenWeChatApp();
                //        LOGGER.Info($"线程检查是否在微信：{result}");
                //        if (!result)
                //        {
                //            // 当后台操作完成时停止定时器
                //            cts.Cancel();
                //            timer.Dispose();
                //            break;
                //        }
                //    }
                //});
                //var pack = await androidBot.GetPackage();
                //LOGGER.Info($"当前活动的包：{pack}");
            }

            while (true) ;

        }

        /// <summary>
        /// 关闭小程序弹窗
        /// </summary>
        /// <param name="androidBot"></param>
        /// <returns></returns>
        private async Task CloseAppletPopup(IAndroidBot androidBot)
        {
            LOGGER.Info("关闭按钮");
            var gb1Xpath = "com.tencent.mm/com.tencent.mm:id=w_/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ImageView";
            if (await androidBot.ClickElement(gb1Xpath))
            {
                LOGGER.Info("找到弹窗关闭按钮1");
            }
            else
            {
                LOGGER.Info("没有找到弹窗关闭按钮1");
            }
            await Task.Delay(2000);
            var gb2Xpath = "com.tencent.mm/com.tencent.mm:id=w_/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.ImageView";
            if (await androidBot.ClickElement(gb2Xpath))
            {
                LOGGER.Info("找到弹窗关闭按钮2");
            }
            else
            {
                LOGGER.Info("没有找到弹窗关闭按钮2");
            }
        }

        public async Task<bool> OpenWenZhang(IAndroidBot androidBot)
        {
            bool isclick = false;
            int i = 0;
            do
            {
                string title = "一位智慧老人的算账，太有了！非看不可，绝对深有启发！";
                var mohu = $"com.tencent.mm/android.widget.TextView@containsText={title}";
                isclick = await androidBot.ClickElement(mohu);
                if (!isclick)
                {
                    var find = await androidBot.FindContainsWords("智慧老人");
                    if (find != null)
                    {
                        LOGGER.Debug("找到智慧老人文字");
                        await Task.Delay(1000);
                        await CloseAppletPopup(androidBot);
                        var middlePoint = find.GetMiddlePosition();
                        isclick = await androidBot.Click(middlePoint.X, middlePoint.Y);
                    }
                }
                if (isclick)
                {
                    return isclick;
                }
                i++;
                if (i >= 10)
                {
                    isclick = true;
                }
                //滑动
                await androidBot.SwipeDownToUp(1500);
                await Task.Delay(4000);
            } while (!isclick);
            return false;
        }
        public async Task<bool> OpenJili(IAndroidBot androidBot)
        {
            for (int h = 0; h <= 10; h++)
            {
                string title = "点击看激励广告广告解锁全文";
                var mohu = $"com.tencent.mm/android.widget.TextView@containsText={title}";
                var click = await androidBot.ClickElement(mohu);
                if (!click)
                {
                    var find = await androidBot.FindContainsWords("点击看激励");
                    if (find != null)
                    {
                        LOGGER.Debug("点击看激励");
                        await Task.Delay(1000);
                        await CloseAppletPopup(androidBot);
                        var middlePoint = find.GetMiddlePosition();
                        click = await androidBot.Click(middlePoint.X, middlePoint.Y);
                    }
                }
                await Task.Delay(2000);
                if (click)
                {
                    // 创建一个取消令牌源，用于在需要时停止定时器
                    for (int i = 0; i < 60; i++)
                    {

                        string gbJili = "已获得奖励";
                        var huodejliXpath = $"com.tencent.mm/android.widget.TextView@containsText={gbJili}";

                        var result = await androidBot.ExistsElement(huodejliXpath);
                        if (result)
                        {
                            var gbjiliXpath = "com.tencent.mm/android.widget.TextView@containsText=关闭";
                            LOGGER.Error("获得奖励，关闭视频");
                            var gbOK = await androidBot.ClickElement(gbjiliXpath);
                            if (gbOK)
                            {
                                return true;
                            }
                            else
                            {
                                var findgb = await androidBot.FindContainsWords("关闭");
                                if (findgb != null)
                                {
                                    var middlePoint = findgb.GetMiddlePosition();
                                    return await androidBot.Click(middlePoint.X, middlePoint.Y);
                                }
                            }

                        }
                        else
                        {
                            await Task.Delay(1000);
                            var find = await androidBot.FindContainsWords("已获得奖励");
                            if (find != null)
                            {
                                var gbjiliXpath = "com.tencent.mm/android.widget.TextView@containsText=关闭";
                                LOGGER.Error("获得奖励，关闭视频");
                                var gbOK = await androidBot.ClickElement(gbjiliXpath);
                                if (gbOK)
                                {
                                    return true;
                                }
                                else
                                {
                                    var findgb = await androidBot.FindContainsWords("关闭");
                                    if (findgb != null)
                                    {
                                        var middlePoint = findgb.GetMiddlePosition();
                                        return await androidBot.Click(middlePoint.X, middlePoint.Y);
                                    }

                                }
                            }
                        }
                        await Task.Delay(2000);
                    }
                    return false;
                }
                await Task.Delay(2000);
                //滑动
                await androidBot.SwipeDownToUp(1500);
            }
            return false;
        }
    }
}
