using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IKey
    {
        public Task<bool> Back();
        public Task<bool> Home();
        public Task<bool> Recents();
        public Task<bool> PowerDialog();
        public Task<bool> SendVk(int vk);
    }
}
