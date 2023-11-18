using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IImageSize
    {
        public async Task<(int width, int height)> GetImageSize(string imagePath)
        {
            var result = await _AndroidBotCore.GetImageSize(imagePath);
            var list = result.Split("|");
            int.TryParse(list[0], out var width);
            int.TryParse(list[1], out var height);
            return (width, height);
        }
    }
}
