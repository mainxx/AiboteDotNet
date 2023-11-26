using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.DataModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IPicturesColors
    {
        public Task<bool> SaveScreenshot(string savePath, BotRectangle region, Threshold threshold);
        public Task<Image> TakeScreenshot(BotRectangle region, Threshold threshold, double scale);
        public Task<string> GetColor(int x, int y);
        public Task<List<BotPoint>> FindImage(string imagePath, int sim, BotRectangle region, Threshold threshold, int multi);
        public Task<List<BotPoint>> FindAnimation(int frameRate, BotRectangle region);
        public Task<List<BotPoint>> FindColor(string mainColor, SubColors subColors, BotRectangle region, int sim);
        public Task<bool> CompareColor(int mainX, int mainY, string mainColor, SubColors subColors, BotRectangle region, int sim);
    }
}
