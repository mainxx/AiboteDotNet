using AiboteDotNet.Core.DataPacket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.Tcp
{
    public static class SendDataExt
    {

        public static async Task<T> SendData<T>(this TcpChannel channel, string funName, params object[] objects)
        {
            var result = await channel.Write(funName.GetDataPacket(objects));
            var msg = Encoding.UTF8.GetString(result);
            return msg.ChangeTo<T>();
        }
        public static T ChangeTo<T>(this string str)
        {
            T result = default(T);
            result = (T)Convert.ChangeType(str, typeof(T));
            return result;
        }
    }
}
