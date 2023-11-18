using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IScriptControl
    {
        public Task<bool> CreateTextView(int id,string text,int x,int y,int width,int height);
        public Task<bool> CreateEditText(int id,string hintText, int x, int y, int width, int height);
        public Task<bool> CreateCheckBox(int id, string text, int x, int y, int width, int height,bool isSelect);
        public Task<bool> CreateListText(int id, string hintText, int x, int y, int width, int height,string listText);
        public Task<bool> CreateWebView(int id, string url, int x, int y, int width, int height);

        public Task<bool> ClearScriptControl();

        public Task<string> GetScriptParam();
    }
}
