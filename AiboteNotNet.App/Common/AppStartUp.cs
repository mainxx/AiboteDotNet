using AiboteDotNet.AndroidBot;
using AiboteDotNet.Core.Tcp;
using AiboteNotNet.App.AndroidLogic;
using AiboteNotNet.App.WebLogic;
using AiboteNotNet.App.WindowsLogic;
using Microsoft.AspNetCore.Connections;
using NLog;
using NLog.Config;

namespace AiboteNotNet.App.Common
{
    internal class AppStartUp
    {
        static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public static async Task Enter()
        {
            try
            {
                var flag = await StartAsync();
                if (!flag) return; //启动服务器失败


                Log.Info("进入主循环...");
                Console.WriteLine("***进入主循环***");
                Settings.LauchTime = DateTime.Now;
                Settings.AppRunning = true;
                TimeSpan delay = TimeSpan.FromSeconds(1);


                while (Settings.AppRunning)
                {
                    await Task.Delay(delay);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"服务器执行异常，e:{e}");
                Log.Fatal(e);
            }

            Console.WriteLine($"退出服务器开始");
            await TcpServer.Stop();
            Console.WriteLine($"退出服务器成功");
        }

        private static async Task<bool> StartAsync()
        {
            try
            {
                LogManager.Configuration = new XmlLoggingConfiguration("Configs/app_log.config");
                Console.WriteLine("init NLog config...");
                Settings.Load("Configs/app.json");
                Console.WriteLine("init config...");
                await TcpServer.Start(Settings.Ins.androidBotServerPort, builder => builder.UseConnectionHandler<AndroidBotHandler>());
                await TcpServer.Start(Settings.Ins.windowsBotServerPort, builder => builder.UseConnectionHandler<WindowsBotHandler>());
                await TcpServer.Start(Settings.Ins.webBotServerPort, builder => builder.UseConnectionHandler<WebBotHandler>());
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"启动服务器失败,异常:{e}");
                return false;
            }
        }
    }
}
