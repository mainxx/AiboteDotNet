using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class SubColors
    {
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public string StrSubColor { get; set; }

        public override string ToString()
        {
            return $"{OffsetX}/{OffsetY}/{StrSubColor}";
        }
    }
}
