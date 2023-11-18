using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IToast
    {
        public Task<bool> ShowToast(string text, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
