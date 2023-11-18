using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IPicturesColors
    {
        public Task<bool> CompareColor(int mainX, int mainY, string mainColor, SubColors subColors,
            Rectangle region, int sim)
        {
            return _AndroidBotCore.CompareColor(mainX, mainY, mainColor, subColors.ToString(),
                region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, sim);
        }

        public Task<List<Point>> FindAnimation(int frameRate, Rectangle region)
        {
            return _AndroidBotCore.FindAnimation(frameRate, region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY);
        }

        public Task<string> FindColor(string mainColor, SubColors subColors, Region region, int sim)
        {
            throw new NotImplementedException();
        }

        public Task<string> FindImage(string imagePath, int sim, Region region, Threshold threshold)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetColor(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveScreenshot(string savePath, Region region, Threshold threshold)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TakeScreenshot(Region region, Threshold threshold)
        {
            throw new NotImplementedException();
        }
    }
}
