using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    /// <summary>
    /// 验证码系统
    /// </summary>
    public interface IVerificationCodeSystem
    {
        public Task<GetCaptchaModel> GetCaptcha(string filePath, string username, string password, string softId, string codeType, int lenMin = 0);

        public Task<ErrorCaptchaModel> ErrorCaptcha(string username, string password, string softId, string picId);

        public Task<ScoreCaptchaModel> ScoreCaptcha(string username, string password);
    }
}
