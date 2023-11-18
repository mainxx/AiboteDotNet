using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public class Threshold
    {
        
        public ThresholdTypes ThresholdType { get; set; }
        public int Thresh { get; set; }
        public int Maxval { get; set; }
    }
}
