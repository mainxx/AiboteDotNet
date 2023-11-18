using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IKey
    {
        public Task<bool> Back()
        {
            return _AndroidBotCore.Back();
        }

        public Task<bool> Home()
        {
            return _AndroidBotCore.Home();
        }

        public Task<bool> PowerDialog()
        {
            return _AndroidBotCore.PowerDialog();
        }

        public Task<bool> Recents()
        {
            return _AndroidBotCore.Recents();
        }

        public Task<bool> SendVk(int vk)
        {
            return _AndroidBotCore.SendVk(vk);
        }
    }
}
