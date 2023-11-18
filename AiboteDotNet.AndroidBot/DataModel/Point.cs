using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class Point
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X}/{Y}";
        }
        public static Point By(string str)
        {
            var point = str.Split("|");
            double.TryParse(point[0], out double x);
            double.TryParse(point[1], out double y);
            return new Point { X = (int)x, Y = (int)y };
        }
        public static List<Point> ByList(string str)
        {
            var points = new List<Point>();      
            var list = str.Split("/");
            foreach (var item in list)
            {
                points.Add(Point.By(item));
            }
            return points;
        }
    }
}
