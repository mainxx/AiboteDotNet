using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IText
    {
        public Task<bool> SendKeys(string text);
    }
}
