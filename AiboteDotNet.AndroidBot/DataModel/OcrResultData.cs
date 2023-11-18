using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class PositionConnent
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }
        public string Connent { get; set; }
        public double Similarity { get; set; }

        /// <summary>
        /// 取得中间位置
        /// </summary>
        /// <returns></returns>
        public Point GetMiddlePosition()
        {
            int middleX = (TopLeft.X + BottomRight.X) / 2;
            int middleY = (TopLeft.Y + BottomRight.Y) / 2;
            return new Point { X = middleX, Y = middleY };
        }

        public static List<PositionConnent> By(string json)
        {
            List<PositionConnent> positionConnents = new List<PositionConnent>();
            try
            {
                if (!string.IsNullOrWhiteSpace(json))
                {
                    JArray rootArray = JArray.Parse(json);
                    foreach (JArray item in rootArray)
                    {
                        var points = item[0].Select(p => new Point { X = (int)p[0], Y = (int)p[1] }).ToList();
                        var data = (JArray)item[1];

                        PositionConnent positionConnent = new PositionConnent
                        {
                            TopLeft = points[0],
                            TopRight = points[1],
                            BottomLeft = points[2],
                            BottomRight = points[3],
                            Connent = data[0].ToString(),
                            Similarity = Convert.ToDouble(data[1])
                        };
                        positionConnents.Add(positionConnent);
                    }
                }
            }
            catch (Exception ex)
            {
                LOGGER.Error(ex);
            }
            return positionConnents;
        }
    }
}
