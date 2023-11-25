using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.DataModel
{
    public class BotPoint
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X}/{Y}";
        }
        public static BotPoint By(string str)
        {
            var point = str.Split("|");
            double.TryParse(point[0], out double x);
            double.TryParse(point[1], out double y);
            return new BotPoint { X = (int)x, Y = (int)y };
        }
        public static List<BotPoint> ByList(string str)
        {
            var points = new List<BotPoint>();      
            var list = str.Split("/");
            foreach (var item in list)
            {
                points.Add(BotPoint.By(item));
            }
            return points;
        }
    }
}
