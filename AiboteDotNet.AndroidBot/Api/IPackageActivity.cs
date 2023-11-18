using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IPackageActivity
    {
        public Task<string> GetActivity();
        public Task<string> GetPackage();
    }
}
