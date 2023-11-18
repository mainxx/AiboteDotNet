using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IVerificationCodeSystem
    {
        public Task<ErrorCaptchaModel> ErrorCaptcha(string username, string password, string softId, string picId)
        {
            return _AndroidBotCore.ErrorCaptcha(username, password, softId, picId);
        }

        public Task<GetCaptchaModel> GetCaptcha(string filePath, string username, string password, string softId, string codeType, int lenMin = 0)
        {
            return _AndroidBotCore.GetCaptcha(filePath, username, password, softId, codeType, lenMin);
        }

        public Task<ScoreCaptchaModel> ScoreCaptcha(string username, string password)
        {
            return _AndroidBotCore.ScoreCaptcha(username, password);
        }
    }
}
