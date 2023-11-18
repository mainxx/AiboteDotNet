using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.DataPacket
{
    public static class DataPacketExt
    {
        public static byte[] GetDataPacket(this string funName, params object[] objects)
        {
            return DataPacketManage.ObjectToDataPacket(funName, objects);
        }
    }
}
