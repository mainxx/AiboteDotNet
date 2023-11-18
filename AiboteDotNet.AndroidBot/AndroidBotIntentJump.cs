using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IIntentJump
    {
        public Task<bool> CallPhone(string phone)
        {
            return _AndroidBotCore.CallPhone(phone);
        }

        public Task<bool> SendMsg(string phone, string text)
        {
            return _AndroidBotCore.SendMsg(phone, text);
        }

        public Task<bool> StartActivity(string activity, string url = "", string packageName = "", string className = "", string type = "")
        {
           return _AndroidBotCore.StartActivity(activity, url, packageName, className, type);   
        }
    }
}
