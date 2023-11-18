using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IFileTransfer
    {
        public Task<bool> PushFile(string pcPath, byte[] fileBytes);
        public Task<byte[]> PullFile(string androidPath, string pcPath);
    }
}
