using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.DataModel
{
    public class BotRectangle
    {
        // int leftTopX, int leftTopY, int rightBottomX, int rightBottomY
        public int LeftTopX { get; set; }
        public int LeftTopY { get; set; }
        public int RightBottomX { get; set; }

        public int RightBottomY { get; set; }

    }
}
