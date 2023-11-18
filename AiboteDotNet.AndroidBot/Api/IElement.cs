using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.AndroidBot.Api
{
    /// <summary>
    /// 元素操作
    /// </summary>
    public interface IElement
    {
        public Task<Region> GetElementRect(string xpath);
        public Task<string> GetElementDescription(string xpath);
        public Task<string> GetElementText(string xpath);
        public Task<bool> ClickElement(string xpath);
        public Task<bool> ScrollElement(string xpath, int direction);
        public Task<bool> ExistsElement(string xpath);
        public Task<bool> IsSelectedElement(string xpath);


    }
}
