using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IToast
    {
        public Task<bool> ShowToast(string text, int duration);
    }
}
