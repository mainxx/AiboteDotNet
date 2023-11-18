using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    
    public partial class AndroidBot : IHid
    {
        public Task<int> GetRotationAngle()
        {
            return _AndroidBotCore.GetRotationAngle();
        }

        public Task<bool> HidClick(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidDispatchGesture(int gesturePath, int duration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidDispatchGestures(string gesturePathsJson)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidDoubleClick(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidLongClick(int x, int y, int duration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidMove(int x, int y, int duration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidPress(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidRelease()
        {
            throw new NotImplementedException();
        }

        public Task<bool> HidSwipe(int startX, int startY, int endX, int endY, int duration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InitHid()
        {
            throw new NotImplementedException();
        }
    }
}
