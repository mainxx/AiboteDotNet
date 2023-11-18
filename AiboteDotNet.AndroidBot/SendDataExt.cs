using AiboteDotNet.Core.DataPacket;
using AiboteDotNet.Core.Tcp;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public static class SendDataExt
    {
        public static async Task<T> SendData<T>(this AndroidBotCore android, string funName, params object[] objects)
        {
            var result = await android.Channel.Write(funName.GetDataPacket(objects));
            var msg = DataPacketManage.DataPacketToDataString(result);
            return msg.ChangeTo<T>();
        }
        public static async Task<byte[]> SendDataByBytes(this AndroidBotCore android, string funName, params object[] objects)
        {
            var result = await android.Channel.Write(funName.GetDataPacket(objects));
            return result;
        }
    }
}
