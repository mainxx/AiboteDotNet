using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IText
    {
        public Task<bool> SendKeys(string text)
        {
            return _AndroidBotCore.SendKeys(text);
        }
    }
}
