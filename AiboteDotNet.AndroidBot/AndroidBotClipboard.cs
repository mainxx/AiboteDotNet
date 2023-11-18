using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IClipboard
    {
        public Task<string> GetClipboardText()
        {
            return _AndroidBotCore.GetClipboardText();
        }

        public Task<bool> SetClipboardText(string text)
        {
            return _AndroidBotCore.SetClipboardText(text);
        }
    }
}
