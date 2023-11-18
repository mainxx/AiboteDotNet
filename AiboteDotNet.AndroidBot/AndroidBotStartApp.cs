using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IStartApp
    {
        public Task<bool> AppIsRunnig(string name)
        {
            return _AndroidBotCore.AppIsRunnig(name);
        }

        public Task<string> GetInstalledPackages()
        {
            return _AndroidBotCore.GetInstalledPackages();
        }

        public Task<bool> StartApp(string name)
        {
            return _AndroidBotCore.StartApp(name);
        }
    }
}
