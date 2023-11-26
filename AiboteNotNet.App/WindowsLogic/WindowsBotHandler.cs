using AiboteDotNet.Core.Session;
using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteNotNet.App.WindowsLogic
{
    public class WindowsBotHandler : TcpConnectionHandler
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public override BotOptions CurBotOptions { get; set; } = BotOptions.WindowsBot;
    }
}
