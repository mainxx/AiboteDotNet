using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IUrlRequest
    {
        public Task<string> UrlRequest(string url, string requestType, string headers = "null", string postData = "null")
        {
            return _AndroidBotCore.UrlRequest(url, requestType, headers, postData);
        }
    }
}
