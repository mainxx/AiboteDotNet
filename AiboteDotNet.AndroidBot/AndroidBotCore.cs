using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.DataModel;
using AiboteDotNet.Core.Tcp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.AndroidBot
{
    /// <summary>
    /// 协议调用
    /// </summary>
    public class AndroidBotCore : IAndroidBotCore
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public TcpChannel Channel { get; set; }

        public AndroidBotCore(TcpChannel tcpChannel)
        {
            Channel = tcpChannel;
        }



        public Task<bool> SaveScreenshot(string savePath, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int AlgorithmType, int threshold, int maxValue)
        {
            return this.SendData<bool>("saveScreenshot", savePath, leftTopX, leftTopY, rightBottomX, rightBottomY, AlgorithmType, threshold, maxValue);
        }

        public async Task<System.Drawing.Image> TakeScreenshot(int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int AlgorithmType, int threshold, int maxValue, double scale)
        {

            var bytes = await this.SendDataByBytes("takeScreenshot", leftTopX, leftTopY, rightBottomX, rightBottomY, AlgorithmType, threshold, maxValue, scale);
            if (bytes != null)
            {
                MemoryStream ms = new MemoryStream(bytes);
                var image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            return null;
        }

        public Task<string> GetColor(int x, int y)
        {
            return this.SendData<string>("getColor", x, y);
        }

        public async Task<List<BotPoint>> FindImage(string savePath, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, double similarity, int AlgorithmType, int threshold, int maxValue, int multiplePoints)
        {
            var str = await this.SendData<string>("getColor", savePath, leftTopX, leftTopY, rightBottomX, rightBottomY, similarity, AlgorithmType, threshold, maxValue, multiplePoints);
            var list = str.Split("/");
            List<BotPoint> points = new List<BotPoint>();
            foreach (var item in list)
            {
                var point = item.Split("|");
                double.TryParse(point[0], out double x);
                double.TryParse(point[1], out double y);
                points.Add(new BotPoint { X = (int)x, Y = (int)y });
            }
            return points;
        }

        public async Task<List<BotPoint>> FindAnimation(int frameRate, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY)
        {
            var str = await this.SendData<string>("findAnimation", frameRate, leftTopX, leftTopY, rightBottomX, rightBottomY);

            return BotPoint.ByList(str);
        }

        public async Task<List<BotPoint>> FindColor(string mainColor, string colorPoints, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int similarity)
        {
            var str = await this.SendData<string>("findColor", mainColor, colorPoints, leftTopX, leftTopY, rightBottomX, rightBottomY, similarity);
            return BotPoint.ByList(str);
        }

        public Task<bool> CompareColor(int x, int y, string mainColor, string colorPoints, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int similarity)
        {
            return this.SendData<bool>("findColor", x, y, mainColor, colorPoints, leftTopX, leftTopY, rightBottomX, rightBottomY, similarity);
        }

        public Task<bool> Press(int x, int y, int duration)
        {
            return this.SendData<bool>("press", x, y, duration);
        }

        public Task<bool> Move(int x, int y, int duration)
        {
            return this.SendData<bool>("move", x, y, duration);
        }

        public Task<bool> Release()
        {
            return this.SendData<bool>("release");
        }

        public Task<bool> Click(int x, int y)
        {
            return this.SendData<bool>("click", x, y);
        }

        public Task<bool> DoubleClick(int x, int y)
        {
            return this.SendData<bool>("doubleClick", x, y);
        }

        public Task<bool> LongClick(int x, int y, int duration)
        {
            return this.SendData<bool>("longClick", x, y, duration);
        }

        public Task<bool> Swipe(int startX, int startY, int endX, int endY, int duration)
        {
            return this.SendData<bool>("swipe", startX, startY, endX, endY, duration);
        }

        public Task<bool> DispatchGesture(string gestureStr, int duration)
        {
            return this.SendData<bool>("dispatchGesture", gestureStr, duration);
        }

        public Task<bool> DispatchGestures(string gestures)
        {
            return this.SendData<bool>("dispatchGestures", gestures);
        }

        public Task<bool> SendKeys(string text)
        {
            return this.SendData<bool>("sendKeys", text);
        }

        public Task<bool> Back()
        {
            return this.SendData<bool>("back");
        }

        public Task<bool> Home()
        {
            return this.SendData<bool>("home");
        }

        public Task<bool> Recents()
        {
            return this.SendData<bool>("recents");
        }

        public Task<bool> PowerDialog()
        {
            return this.SendData<bool>("powerDialog");
        }

        public Task<bool> SendVk(int vk)
        {
            return this.SendData<bool>("sendVk", vk);
        }

        public Task<bool> StartApp(string name)
        {
            return this.SendData<bool>("startApp", name);
        }

        public Task<bool> AppIsRunnig(string name)
        {
            return this.SendData<bool>("appIsRunnig", name);
        }

        public Task<string> GetInstalledPackages()
        {
            return this.SendData<string>("getInstalledPackages");
        }

        public async Task<(int width, int height)> GetWindowSize()
        {
            var result = await this.SendData<string>("getWindowSize");
            var array = result.Split("|");
            double.TryParse(array[0], out double width);
            double.TryParse(array[1], out double height);
            return ((int)width, (int)height);
        }

        public Task<string> GetImageSize(string imgPath)
        {
            return this.SendData<string>("getImageSize", imgPath);
        }

        public Task<string> GetAndroidId()
        {
            return this.SendData<string>("getAndroidId");
        }

        public Task<string> GetGroup()
        {
            return this.SendData<string>("getGroup");
        }

        public Task<string> GetIdentifier()
        {
            return this.SendData<string>("getIdentifier");
        }

        public Task<string> GetTitle()
        {
            return this.SendData<string>("getTitle");
        }

        public Task<bool> InitOcr(string serverIp, int prot = 9527)
        {
            return this.SendData<bool>("initOcr", serverIp, prot);
        }

        public async Task<List<PositionConnent>> Ocr(int left = 0, int top = 0, int right = 0, int bottom = 0, int thresholdType = 0, int thresh = 0, int maxval = 0, double scale = 1)
        {
            List<PositionConnent> positionConnents = new List<PositionConnent>();
            string json = await this.SendData<string>("ocr", left, top, right, bottom, thresholdType, thresh, maxval, scale);
            return PositionConnent.By(json);
        }

        public Task<string> UrlRequest(string url, string method, string headers, string postData)
        {
            return this.SendData<string>("UrlRequest", url, method, headers, postData);
        }

        public Task<bool> ShowToast(string text, int duration)
        {
            return this.SendData<bool>("showToast", text, duration);
        }

        public async Task<GetCaptchaModel> GetCaptcha(string imgPath, string userName, string password, string softId, string codeType, int lenMin = 0)
        {
            var str = await this.SendData<string>("getCaptcha", imgPath, userName, password, softId, codeType, lenMin);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetCaptchaModel>(str);
        }

        public async Task<ErrorCaptchaModel> ErrorCaptcha(string userName, string password, string softId, string picId)
        {
            var str = await this.SendData<string>("errorCaptcha", userName, password, softId, picId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorCaptchaModel>(str);
        }

        public async Task<ScoreCaptchaModel> ScoreCaptcha(string userName, string password)
        {
            var str = await this.SendData<string>("scoreCaptcha", userName, password);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ScoreCaptchaModel>(str);
        }

        public async Task<Region> GetElementRect(string xpath)
        {
            var data = await this.SendData<string>("getElementRect", xpath);
            return Region.By(data);
        }

        public Task<string> GetElementText(string xpath)
        {
            return this.SendData<string>("getElementText", xpath);
        }

        public Task<bool> SetElementText(string xpath)
        {
            return this.SendData<bool>("setElementText", xpath);
        }

        public Task<bool> ClickElement(string xpath)
        {
            return this.SendData<bool>("clickElement", xpath);
        }

        public Task<bool> ScrollElement(string xpath, int direction)
        {
            return this.SendData<bool>("scrollElement", xpath, direction);
        }

        public Task<bool> ExistsElement(string xpath)
        {
            return this.SendData<bool>("existsElement", xpath);
        }

        public Task<bool> IsSelectedElement(string xpath)
        {
            return this.SendData<bool>("isSelectedElement", xpath);
        }

        public Task<bool> PushFile(string filePath, byte[] bytes)
        {
            return this.SendData<bool>("pushFile", filePath, bytes);
        }

        public Task<byte[]> PullFile(string androidFilePath, string pcSavePath)
        {
            //TODO byte类型需要额外处理
            return this.SendDataByBytes("pullFile", androidFilePath, pcSavePath);
        }

        public Task<bool> WriteAndroidFile(string androidFilePath, string writeText, bool isAppend)
        {
            return this.SendData<bool>("writeAndroidFile", androidFilePath, writeText, isAppend);
        }

        public Task<string> ReadAndroidFile(string androidFilePath)
        {
            return this.SendData<string>("readAndroidFile", androidFilePath);
        }

        public Task<bool> DeleteAndroidFile(string androidFilePath)
        {
            return this.SendData<bool>("DeleteAndroidFile", androidFilePath);
        }

        public Task<bool> ExistsAndroidFile(string androidFilePath)
        {
            return this.SendData<bool>("existsAndroidFile", androidFilePath);
        }

        public async Task<string[]> GetAndroidSubFiles(string androidPath)
        {
            var data = await this.SendData<string>("getAndroidSubFiles", androidPath);
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }
            return data.Split("|");
        }

        public Task<bool> MakeAndroidDir(string androidPath)
        {
            return this.SendData<bool>("makeAndroidDir", androidPath);
        }

        public Task<bool> StartActivity(string activity, string uri = "", string packageName = "", string className = "", string type = "")
        {
            return this.SendData<bool>("startActivity", activity, uri, packageName, className, type);
        }

        public Task<bool> CallPhone(string phone)
        {
            return this.SendData<bool>("callPhone", phone);
        }

        public Task<bool> SendMsg(string phone, string msg)
        {
            return this.SendData<bool>("sendMsg", phone, msg);
        }

        public Task<string> GetActivity()
        {
            return this.SendData<string>("getActivity");
        }

        public Task<string> Package()
        {
            return this.SendData<string>("package");
        }

        public Task<bool> SetClipboardText(string text)
        {
            return this.SendData<bool>("setClipboardText", text);
        }

        public Task<string> GetClipboardText()
        {
            return this.SendData<string>("getClipboardText");
        }

        public Task<bool> CreateTextView(int id, string hintText, int x, int y, int width, int height)
        {
            return this.SendData<bool>("createTextView", id, hintText, x, y, width, height);
        }

        public Task<bool> CreateEditText(int id, string hintText, int x, int y, int width, int height)
        {
            return this.SendData<bool>("createEditText", id, hintText, x, y, width, height);
        }

        public Task<bool> CreateCheckBox(int id, string hintText, int x, int y, int width, int height, bool isSelect)
        {
            return this.SendData<bool>("createCheckBox", id, hintText, x, y, width, height, isSelect);
        }

        public Task<bool> CreateListText(int id, string hintText, int x, int y, int width, int height, string items)
        {
            return this.SendData<bool>("createListText", id, hintText, x, y, width, height, items);
        }

        public Task<bool> CreateWebView(int id, string url, int x, int y, int width, int height)
        {
            return this.SendData<bool>("createWebView", id, url, x, y, width, height);
        }

        public Task<bool> ClearScriptControl()
        {
            return this.SendData<bool>("clearScriptControl");
        }

        public Task<string> GetScriptParam()
        {
            return this.SendData<string>("getScriptParam");
        }

        public Task<bool> InitAccessory()
        {
            return this.SendData<bool>("initAccessory");
        }

        public Task<int> GetRotationAngle()
        {
            return this.SendData<int>("getRotationAngle");
        }

        public Task<bool> CloseDriver()
        {
            return this.SendData<bool>("closeDriver");
        }

        public Task<string> GetElementDescription(string xpath)
        {
            return this.SendData<string>("getElementDescription", xpath);
        }

        public Task<string> GetPackage()
        {
            return this.SendData<string>("getPackage");
        }
    }
}
