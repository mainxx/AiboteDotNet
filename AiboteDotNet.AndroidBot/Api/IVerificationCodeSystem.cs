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
        public Task<string> GetCaptcha(string filePath, string username, string password, string softId, string codeType, string lenMin = "0");

        public Task<string> ErrorCaptcha(string username, string password, string softId, string picId);

        public Task<string> ScoreCaptcha(string username, string password);
    }
}
