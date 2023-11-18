using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.DataModel
{
    public enum ThresholdTypes
    {
        //0   THRESH_BINARY算法，当前点值大于阈值thresh时，取最大值maxva，否则设置为0
        //1   THRESH_BINARY_INV算法，当前点值大于阈值thresh时，设置为0，否则设置为最大值maxva
        //2   THRESH_TOZERO算法，当前点值大于阈值thresh时，不改变，否则设置为0
        //3   THRESH_TOZERO_INV算法，当前点值大于阈值thresh时，设置为0，否则不改变
        //4   THRESH_TRUNC算法，当前点值大于阈值thresh时，设置为阈值thresh，否则不改变
        //5   ADAPTIVE_THRESH_MEAN_C算法，自适应阈值
        //6   ADAPTIVE_THRESH_GAUSSIAN_C算法，自适应阈值
        THRESH_BINARY = 0,
        THRESH_BINARY_INV = 1,
        THRESH_TOZERO = 2,
        THRESH_TOZERO_INV = 3,
        THRESH_TRUNC = 4,
        ADAPTIVE_THRESH_MEAN_C = 5,
        ADAPTIVE_THRESH_GAUSSIAN_C = 6,

    }
}
