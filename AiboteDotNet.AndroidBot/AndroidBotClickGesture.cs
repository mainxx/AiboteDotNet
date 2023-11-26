using AiboteDotNet.AndroidBot.Api;
using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IClickGesture
    {
        public Task<bool> Click(int x, int y)
        {
            return _AndroidBotCore.Click(x, y);
        }

        public Task<bool> DispatchGesture(GesturePath gesturePath)
        {
            return _AndroidBotCore.DispatchGesture(gesturePath?.ByGesturePathStrData(), gesturePath.Duration);
        }

        public Task<bool> DispatchGesture(int x, int y, int x1, int y1, int duration)
        {
            return _AndroidBotCore.DispatchGesture($"{x}/{y}\n{x1}/{y1}", duration);
        }

        public Task<bool> DispatchGesture(BotPoint begin, BotPoint end, int duration)
        {
            return _AndroidBotCore.DispatchGesture($"{begin.ToString()}\n{begin.ToString()}", duration);
        }

        public Task<bool> DispatchGestures(GesturePath[] gesturesPath)
        {
            return _AndroidBotCore.DispatchGestures(GesturePath.GetByGesturesPathStrData(gesturesPath));
        }

        public Task<bool> DoubleClick(int x, int y)
        {
            return _AndroidBotCore.DoubleClick(x, y);
        }

        public Task<bool> LongClick(int x, int y, int duration)
        {
            return _AndroidBotCore.LongClick(x, y, duration);
        }

        public Task<bool> Move(int x, int y, int duration)
        {
            return _AndroidBotCore.Move(x, y, duration);
        }

        public Task<bool> Press(int x, int y, int duration)
        {
            return _AndroidBotCore.Press(x, y, duration);
        }

        public Task<bool> Release()
        {
            return _AndroidBotCore.Release();
        }

        public Task<bool> Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            return _AndroidBotCore.Swipe(startX, startY, endX, endY, duration);
        }

        /// <summary>
        /// 根据屏幕滑动，从屏幕下方滑到上方，三分之一屏
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SwipeDownToUp(int duration)
        {
            (int w, int h) = await _AndroidBotCore.GetWindowSize();
            return await Swipe(w / 2, h - (h / 5), w / 2, h / 5, duration);
        }
    }
}
