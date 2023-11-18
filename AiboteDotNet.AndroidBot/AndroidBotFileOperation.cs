using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IAndroidFileOperation
    {
        public Task<bool> DeleteAndroidFile(string filePath)
        {
            return _AndroidBotCore.DeleteAndroidFile(filePath);
        }

        public Task<bool> ExistsAndroidFile(string filePath)
        {
            return _AndroidBotCore.ExistsAndroidFile(filePath);
        }

        public Task<string[]> GetAndroidSubFiles(string filePath)
        {
            return _AndroidBotCore.GetAndroidSubFiles(filePath);
        }

        public Task<bool> MakeAndroidDir(string path)
        {
            return _AndroidBotCore.MakeAndroidDir(path);
        }

        public Task<string> ReadAndroidFile(string filePath)
        {
            return _AndroidBotCore.ReadAndroidFile(filePath);
        }

        public Task<bool> WriteAndroidFile(string filePath, string text, bool isAppend = false)
        {
            return _AndroidBotCore.WriteAndroidFile(filePath, text, isAppend);
        }
    }
}
