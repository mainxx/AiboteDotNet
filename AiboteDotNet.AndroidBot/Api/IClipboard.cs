using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IClipboard
    {
        public Task<bool> SetClipboardText(string text);
        public Task<string> GetClipboardText();
    }
}
