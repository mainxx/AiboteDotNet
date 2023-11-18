using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.Core.Session
{
    public class Session
    {
        /// <summary>
        /// 全局标识符
        /// </summary>
        public Guid Id { set; get; }

        /// <summary>
        /// 连接时间
        /// </summary>
        public DateTime Time { set; get; }

        /// <summary>
        /// 连接上下文
        /// </summary>
        public TcpChannel Channel { get; set; }

        /// <summary>
        /// 连接标示，
        /// </summary>
        public string Sign { get; set; }

        public BotOptions BotOption { get; set; }


    }
}
