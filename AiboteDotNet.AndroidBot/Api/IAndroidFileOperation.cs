using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IAndroidFileOperation
    {

        public Task<bool> WriteAndroidFile(string filePath, string text, bool isAppend = false);
        public Task<string> ReadAndroidFile(string filePath);

        public Task<bool> DeleteAndroidFile(string filePath);

        public Task<bool> ExistsAndroidFile(string filePath);

        public Task<string[]> GetAndroidSubFiles(string filePath);
        public Task<bool> MakeAndroidDir(string path);
    }
}
