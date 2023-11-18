using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class GesturePath
    {
        public int Duration { get; set; }

        public List<BotPoint> Points { get; set; }

        public string ByGesturePathStrData()
        {
            if (Points != null && Points.Count > 0)
            {
                return string.Join("\n", Points.Select(x => x.ToString()));
            }
            return null;
        }

        public static string GetByGesturesPathStrData(List<GesturePath> list)
        {
            return GetByGesturesPathStrData(list.ToArray()); 
        }
        public static string GetByGesturesPathStrData(GesturePath[] list)
        {
            List<string> result = new List<string>(); ;
            foreach (GesturePath path in list)
            {
                if (path.Points != null && path.Points.Count > 0)
                {
                    var strPoints = string.Join("\n", path.Points.Select(x => x.ToString()));
                    result.Add($"{path.Duration}/{strPoints}");
                }
            }
            return string.Join("\r\n", result); 
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
