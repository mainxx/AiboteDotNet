using AiboteDotNet.Core;
using AiboteDotNet.Core.Session;
using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IAndroidBot
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        protected IAndroidBotCore _AndroidBotCore;
        public AndroidBot(TcpChannel tcpChannel)
        {
            _AndroidBotCore = new AndroidBotCore(tcpChannel);
        }
        public void Debug(string msg)
        {
            LOGGER.Debug($"{_AndroidBotCore.Channel.SessionId}[{_AndroidBotCore.Channel.RemoteAddress}]:{msg}");
        }
    }
}
