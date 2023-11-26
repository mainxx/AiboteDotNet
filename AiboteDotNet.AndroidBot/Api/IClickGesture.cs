using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IClickGesture
    {
        public Task<bool> Press(int x, int y, int duration);
        public Task<bool> Move(int x, int y, int duration);
        public Task<bool> Release();
        public Task<bool> Click(int x, int y);
        public Task<bool> DoubleClick(int x, int y);
        public Task<bool> LongClick(int x, int y, int duration);
        public Task<bool> Swipe(int startX, int startY, int endX, int endY, int duration);
        public Task<bool> SwipeDownToUp(int duration);
        public Task<bool> DispatchGesture(GesturePath gesturePath);
        public Task<bool> DispatchGesture(int x, int y, int x1, int y1, int duration);
        public Task<bool> DispatchGesture(BotPoint begin, BotPoint end, int duration);
        public Task<bool> DispatchGestures(GesturePath[] gesturesPath);
    }
}
