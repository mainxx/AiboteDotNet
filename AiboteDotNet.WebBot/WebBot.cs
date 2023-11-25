using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.WebBot
{
    public class WebBot : WebBotCore, IWebBot
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        protected IWebBotCore _WebBotCore;
        public WebBot(TcpChannel tcpChannel) : base(tcpChannel)
        {
            _WebBotCore = new WebBotCore(tcpChannel);
        }
        public void Debug(string msg)
        {
            LOGGER.Debug($"{_WebBotCore.Channel.SessionId}[{_WebBotCore.Channel.RemoteAddress}]:{msg}");
        }
    }
}
