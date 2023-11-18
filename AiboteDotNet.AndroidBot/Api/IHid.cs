using AiboteDotNet.AndroidBot.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IHid
    {
        public Task<bool> InitHid();

        public Task<bool> HidPress(int x, int y);

        public Task<bool> HidMove(int x, int y, int duration);

        public Task<bool> HidRelease();

        public Task<bool> HidClick(int x, int y);

        public Task<bool> HidDoubleClick(int x, int y);

        public Task<bool> HidLongClick(int x, int y, int duration);

        public Task<bool> HidSwipe(int startX, int startY, int endX, int endY, int duration);

        public Task<bool> HidDispatchGesture(int gesturePath,int duration);

        public Task<bool> HidDispatchGestures(string  gesturePathsJson);

        public Task<int> GetRotationAngle();
    }
}
