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
        public Task<string> RrlRequest(string url, string requestType, string headers = "null", string postData = "null")
        {
            throw new NotImplementedException();
        }
    }
}
