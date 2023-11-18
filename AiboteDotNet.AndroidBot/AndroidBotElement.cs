using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IElement
    {
        public Task<bool> ClickElement(string xpath)
        {
            return _AndroidBotCore.ClickElement(xpath);
        }

        public Task<bool> ExistsElement(string xpath)
        {
            return _AndroidBotCore.ExistsElement(xpath);
        }

        public Task<string> GetElementDescription(string xpath)
        {
            return _AndroidBotCore.GetElementDescription(xpath);
        }

        public async Task<Region> GetElementRect(string xpath)
        {
            return await _AndroidBotCore.GetElementRect(xpath);

        }

        public Task<string> GetElementText(string xpath)
        {
            return _AndroidBotCore.GetElementText(xpath);
        }

        public Task<bool> IsSelectedElement(string xpath)
        {
            return _AndroidBotCore.IsSelectedElement(xpath);
        }

        public Task<bool> ScrollElement(string xpath, int direction)
        {
            return _AndroidBotCore.ScrollElement(xpath, direction);
        }
    }
}
