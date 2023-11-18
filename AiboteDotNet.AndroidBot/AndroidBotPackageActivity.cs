using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IPackageActivity
    {
        public Task<string> GetActivity()
        {
            return _AndroidBotCore.GetActivity();
        }

        public Task<string> GetPackage()
        {
            return _AndroidBotCore.GetPackage();
        }
    }
}
