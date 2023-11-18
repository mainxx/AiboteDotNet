using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IFileTransfer
    {
        public Task<byte[]> PullFile(string androidPath, string pcPath)
        {
            return _AndroidBotCore.PullFile(androidPath, pcPath);
        }

        public Task<bool> PushFile(string pcPath, byte[] bytes)
        {
            return _AndroidBotCore.PushFile(pcPath, bytes);
        }
    }
}
