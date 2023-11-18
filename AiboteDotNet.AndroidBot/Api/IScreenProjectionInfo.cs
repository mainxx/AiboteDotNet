using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IScreenProjectionInfo
    {
        public Task<string> GetAndroidId();
        public Task<string> GetGroup();
        public Task<string> GetIdentifier();
        public Task<string> GetTitle();

    }
}
