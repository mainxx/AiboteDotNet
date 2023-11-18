using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class Region
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        /// <summary>
        /// 数据转换
        /// </summary>
        /// <param name="data">"239|628|989|764" {left:number, top:number, right:number, bottom:number}</param>
        /// <returns></returns>
        public static Region By(string data)
        {
            if (data == null)
            {
                return null;
            }
            Region region = new Region();
            var split = data.Split("|");
            region.Left = int.Parse(split[0]);
            region.Top = int.Parse(split[1]);
            region.Right = int.Parse(split[2]);
            region.Bottom = int.Parse(split[3]);
            return region;
        }
    }
}
