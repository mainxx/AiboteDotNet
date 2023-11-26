using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IPicturesColors
    {
        public Task<bool> CompareColor(int mainX, int mainY, string mainColor, SubColors subColors,
            BotRectangle region, int sim)
        {
            return _AndroidBotCore.CompareColor(mainX, mainY, mainColor, subColors.ToString(),
                region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, sim);
        }

        public Task<List<BotPoint>> FindAnimation(int frameRate, BotRectangle region)
        {
            return _AndroidBotCore.FindAnimation(frameRate, region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY);
        }

        public Task<List<BotPoint>> FindColor(string mainColor, SubColors subColors, BotRectangle region, int sim)
        {
            return _AndroidBotCore.FindColor(mainColor, subColors.ToString(), region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, sim);
        }

        public Task<List<BotPoint>> FindImage(string imagePath, int sim, BotRectangle region, Threshold threshold, int multi = 1)
        {
            return _AndroidBotCore.FindImage(imagePath, region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, sim, threshold.ThresholdType.GetHashCode(), threshold.Thresh, threshold.Maxval, multi);
        }

        public Task<string> GetColor(int x, int y)
        {
            return _AndroidBotCore.GetColor(x, y);
        }

        public Task<bool> SaveScreenshot(string savePath, BotRectangle region, Threshold threshold)
        {
            return _AndroidBotCore.SaveScreenshot(savePath, region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, threshold.ThresholdType.GetHashCode(), threshold.Thresh, threshold.Maxval);
        }

        public Task<Image> TakeScreenshot(BotRectangle region, Threshold threshold, double scale)
        {
            return _AndroidBotCore.TakeScreenshot(region.LeftTopX, region.LeftTopY, region.RightBottomX, region.RightBottomY, threshold.ThresholdType.GetHashCode(), threshold.Thresh, threshold.Maxval, scale);
        }


    }
}
