using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IStartApp
    {
        public Task<bool> StartApp(string name);
        public Task<bool> AppIsRunnig(string name);
        public Task<string> GetInstalledPackages();
    }
}
