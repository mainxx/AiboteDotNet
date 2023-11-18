using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public partial class AndroidBot : IWeChat
    {
        private static string WeChatPackageName = "com.tencent.mm";
        public async Task<string> GetCurrentWeChatPage()
        {
            if (!await IsOpenWeChatApp())
            {
                Debug("没有打开微信");
                return null;
            }
            throw new NotImplementedException();
        }

        public async Task<bool> GotoFaXian()
        {
            if (!await IsOpenWeChatApp())
            {
                Debug("没有打开微信");
                return false;
            }
            var faxianXpath = "com.tencent.mm/com.tencent.mm:id=h7q[2]";
            return await ClickElement(faxianXpath);
        }

        public async Task<bool> GotoFaXian_Applet(string appletName)
        {
            if (!await IsOpenWeChatApp())
            {
                Debug("没有打开微信");
                return false;
            }
            //随机
            if (await GotoFaXian())
            {
                Random random = new Random();
                await Task.Delay(random.Next(2000, 4100));
                var xpath = "com.tencent.mm/android:id=title[3]";
                if (!await ClickElement(xpath))
                {
                    Debug("没有点击到发现-小程序");
                    return false;
                }
                await Task.Delay(random.Next(4000, 8000));

                var ocrResult = await FindWords(appletName);
                if (ocrResult != null)
                {
                    var middlePoint = ocrResult.GetMiddlePosition();
                    return await Click(middlePoint.X, middlePoint.Y);
                }
            }
            return false;
        }

        public async Task<bool> IsOpenWeChatApp()
        {
            string package = await GetPackage();
            if (package == WeChatPackageName)
            {
                return true;
            }
            return false;
        }

        public Task<bool> OpenApplet(string appletName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StartWeChatApp()
        {
            if (await IsOpenWeChatApp())
            {
                return true;
            }
            return await StartApp(WeChatPackageName);
        }
    }
}
