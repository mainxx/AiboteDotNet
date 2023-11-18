using AiboteDotNet.AndroidBot.DataModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IPicturesColors
    {
        public Task<bool> SaveScreenshot(string savePath, Region region, Threshold threshold);
        public Task<bool> TakeScreenshot(Region region, Threshold threshold);
        public Task<string> GetColor(int x, int y);
        public Task<string> FindImage(string imagePath, int sim, Region region, Threshold threshold);
        public Task<List<Point>> FindAnimation(int frameRate, Rectangle region);
        public Task<string> FindColor(string mainColor, SubColors subColors, Region region, int sim);
        public Task<bool> CompareColor(int mainX, int mainY, string mainColor, SubColors subColors, Rectangle region, int sim);
    }
}
