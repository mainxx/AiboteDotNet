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
            throw new NotImplementedException();
        }

        public Task<bool> CreateCheckBox(int id, string text, int x, int y, int width, int height, bool isSelect)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateEditText(int id, string hintText, int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateListText(int id, string hintText, int x, int y, int width, int height, string listText)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateTextView(int id, string text, int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateWebView(int id, string url, int x, int y, int width, int height)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetScriptParam()
        {
            throw new NotImplementedException();
        }
    }
}
