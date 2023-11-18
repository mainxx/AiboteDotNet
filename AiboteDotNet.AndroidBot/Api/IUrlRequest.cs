using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IUrlRequest
    {
        public Task<string> RrlRequest(string url, string requestType, string headers = "null", string postData = "null");
    }
}
