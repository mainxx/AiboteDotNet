using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.DataPacket
{
    public static class DataPacketManage
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public static byte[] ObjectToDataPacket(string funName, params object[] objects)
        {
            // 存储长度信息的列表，第一个元素为函数名长度
            List<int> lenList = new List<int>();
            lenList.Add(funName.Length);

            // 存储数据的列表，第一个元素为函数名的字节数组
            List<byte> dataList = new List<byte>();
            dataList.AddRange(Encoding.UTF8.GetBytes(funName));

            // 遍历参数列表
            foreach (object obj in objects)
            {
                if (obj != null)
                {
                    if (obj is byte[] byteArray)
                    {
                        // 如果参数是字节数组，添加长度和数组本身
                        lenList.Add(byteArray.Length);
                        dataList.AddRange(byteArray);
                    }
                    else
                    {
                        // 如果参数不是字节数组，将其转换为字符串并添加长度和值
                        var str = obj.ToString();
                        lenList.Add(str.Length);
                        dataList.AddRange(Encoding.UTF8.GetBytes(str));
                    }
                }
            }

            // 将长度列表转换为用"/"分隔的字符串的字节数组
            string lenSte = string.Join("/", lenList);
            lenSte += "\n";
            byte[] lenBytes = Encoding.UTF8.GetBytes(lenSte);


            // 合并长度和数据字节数组
            byte[] result = lenBytes.Concat(dataList.ToArray()).ToArray();

            return result;
        }

        public static string DataPacketToDataString(byte[] dataPacket)
        {
            if (dataPacket == null)
            {
                return null;
            }
            var msg = Encoding.UTF8.GetString(dataPacket);
            LOGGER.Debug("收到数据：" + msg);
            return msg;
        }
    }
}
