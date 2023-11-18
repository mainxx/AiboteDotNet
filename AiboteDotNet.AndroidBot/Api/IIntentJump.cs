using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IIntentJump
    {
        public Task<bool> StartActivity(string activity, string url = "",
            string packageName = "", string className = "", string type = "");

        public Task<bool> CallPhone(string phone);

        public Task<bool> SendMsg(string phone, string text);
    }
}

