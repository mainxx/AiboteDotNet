using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IWeChat
    {
        /// <summary>
        /// 启动微信APP
        /// </summary>
        /// <returns></returns>
        public Task<bool> StartWeChatApp();
        /// <summary>
        /// 是否打开微信
        /// </summary>
        /// <returns></returns>
        public Task<bool> IsOpenWeChatApp();

        /// <summary>
        /// 打开某个小程序
        /// </summary>
        /// <param name="appletName"></param>
        /// <returns></returns>
        public Task<bool> OpenApplet(string appletName);
        /// <summary>
        /// 跳转到发现
        /// </summary>
        /// <returns></returns>
        public Task<bool> GotoFaXian();
        /// <summary>
        /// 跳转到发现-小程序,打开小程序
        /// </summary>
        /// <returns></returns>
        public Task<bool> GotoFaXian_Applet(string appletName);
        /// <summary>
        /// 获取当前所在的微信页面
        /// </summary>
        /// <returns></returns>
        public Task<string> GetCurrentWeChatPage();

    }
}
