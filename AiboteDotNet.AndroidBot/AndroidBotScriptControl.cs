using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IScriptControl
    {
        public Task<bool> ClearScriptControl()
        {
            return _AndroidBotCore.ClearScriptControl();
        }

        public Task<bool> CreateCheckBox(int id, string text, int x, int y, int width, int height, bool isSelect)
        {
            return _AndroidBotCore.CreateCheckBox(id, text, x, y, width, height, isSelect);
        }

        public Task<bool> CreateEditText(int id, string hintText, int x, int y, int width, int height)
        {
            return _AndroidBotCore.CreateEditText(id, hintText, x, y, width, height);
        }

        public Task<bool> CreateListText(int id, string hintText, int x, int y, int width, int height, string listText)
        {
            return _AndroidBotCore.CreateListText(id, hintText, x, y, width, height, listText);
        }

        public Task<bool> CreateTextView(int id, string text, int x, int y, int width, int height)
        {
            return _AndroidBotCore.CreateTextView(id, text, x, y, width, height);
        }

        public Task<bool> CreateWebView(int id, string url, int x, int y, int width, int height)
        {
            return _AndroidBotCore.CreateWebView(id, url, x, y, width, height);
        }

        public Task<string> GetScriptParam()
        {
            return _AndroidBotCore.GetScriptParam();
        }
    }
}
