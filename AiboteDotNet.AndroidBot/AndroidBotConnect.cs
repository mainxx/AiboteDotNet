using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IConnect
    {
        public Task CloseDriver()
        {
           return _AndroidBotCore.CloseDriver();
        }
    }
}
