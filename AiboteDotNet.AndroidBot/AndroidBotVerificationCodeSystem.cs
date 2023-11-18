using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IVerificationCodeSystem
    {
        public Task<string> ErrorCaptcha(string username, string password, string softId, string picId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCaptcha(string filePath, string username, string password, string softId, string codeType, string lenMin = "0")
        {
            throw new NotImplementedException();
        }

        public Task<string> ScoreCaptcha(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
