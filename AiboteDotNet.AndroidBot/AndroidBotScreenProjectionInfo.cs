using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IScreenProjectionInfo
    {
        public Task<string> GetAndroidId()
        {
            return _AndroidBotCore.GetAndroidId();
        }

        public Task<string> GetGroup()
        {
            return _AndroidBotCore.GetGroup();
        }

        public Task<string> GetIdentifier()
        {
            return _AndroidBotCore.GetIdentifier();
        }

        public Task<string> GetTitle()
        {
            return _AndroidBotCore.GetTitle();
        }
    }
}
