using AiboteDotNet.AndroidBot.DataModel;
using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public interface IAndroidBotCore
    {
        public TcpChannel Channel { get; set; }
        //截图保存
        // 参数二：保存的图片路径（手机）
        // 参数三：矩形左上角x坐标
        // 参数四：矩形左上角y坐标
        // 参数五：矩形右下角x坐标
        // 参数六：矩形右下角y坐标
        // 参数七：二值化算法类型
        // 参数八：二值化阈值
        // 参数九：二值化最大值
        public Task<bool> SaveScreenshot(string savePath, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int AlgorithmType, int threshold, int maxValue);
        //截图
        // 参数二：矩形左上角x坐标
        // 参数三：矩形左上角y坐标
        // 参数四：矩形右下角x坐标
        // 参数五：矩形右下角y坐标
        // 参数六：二值化算法类型
        // 参数七：二值化阈值
        // 参数八：二值化最大值
        // 参数九：图片缩放率, 默认为 1.0 原大小。小于1.0缩小，大于1.0放大
        public Task<System.Drawing.Image> TakeScreenshot(int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int AlgorithmType, int threshold, int maxValue, double zoomRate);
        //获取色值
        // 参数二：x坐标
        // 参数三：y坐标
        public Task<string> GetColor(int x, int y);
        //找图
        // 参数二：保存的图片路径（手机），多张小图查找应当用"|"分开小图路径
        // 参数三：矩形左上角x坐标
        // 参数四：矩形左上角y坐标
        // 参数五：矩形右下角x坐标
        // 参数六：矩形右下角y坐标
        // 参数七：相似度
        // 参数八：二值化算法类型
        // 参数九：二值化阈值
        // 参数十：二值化最大值
        // 参数十一：多个坐标点
        public Task<List<Point>> FindImage(string savePath, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, double similarity, int AlgorithmType, int threshold, int maxValue, int multiplePoints);
        //找动态图
        // 参数二：前后两张图相隔的时间，单位毫秒
        // 参数三：矩形左上角x坐标
        // 参数四：矩形左上角y坐标
        // 参数五：矩形右下角x坐标
        // 参数六：矩形右下角y坐标
        public Task<List<Point>> FindAnimation(int frameRate, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY);
        //找色
        // 参数二：主颜色值
        // 参数三：相对偏移的颜色点，以 "x坐标+y坐标+色值" 字符串形式 10/20/#e7f0f7
        // 参数四：矩形左上角x坐标
        // 参数五：矩形左上角y坐标
        // 参数六：矩形右下角x坐标
        // 参数七：矩形右下角y坐标
        // 参数八：相似度
        public Task<List<Point>> FindColor(string mainColor, string colorPoints, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int similarity);
        //比色
        // 参数二：主颜色值所在的X坐标
        // 参数三：主颜色值所在的Y坐标
        // 参数四：主颜色值
        // 参数五：相对偏移的颜色点，以 "x坐标+y坐标+色值" 字符串形式
        // 参数六：矩形左上角x坐标
        // 参数七：矩形左上角y坐标
        // 参数八：矩形右下角x坐标
        // 参数九：矩形右下角y坐标
        // 参数十：相似度
        public Task<bool> CompareColor(int x, int y, string mainColor, string colorPoints, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int similarity);
        //手指按下
        // 参数二：x坐标
        // 参数三：y坐标
        // 参数四：按下持续时间
        public Task<bool> Press(int x, int y, int duration);
        //手指移动
        // 参数二：x坐标
        // 参数三：y坐标
        // 参数四：按下持续时间
        public Task<bool> Move(int x, int y, int duration);
        //手指抬起
        public Task<bool> Release();
        //点击坐标
        // 参数二：x坐标
        // 参数三：y坐标
        public Task<bool> Click(int x, int y);
        //双击坐标
        // 参数二：x坐标
        // 参数三：y坐标
        public Task<bool> DoubleClick(int x, int y);
        //长按坐标
        // 参数二：x坐标
        // 参数三：y坐标
        // 参数四：长按持续时间
        public Task<bool> LongClick(int x, int y, int duration);
        //滑动坐标
        // 参数二：开始x坐标
        // 参数三：开始y坐标
        // 参数四：结束x坐标
        // 参数五：结束y坐标
        // 参数六：滑动耗时
        public Task<bool> Swipe(int startX, int startY, int endX, int endY, int duration);
        //执行手势
        // 参数二：执行手势坐标位， 以"/"分割横纵坐标 "\n"分割坐标点。注意：末尾坐标点没有\n结束
        // 参数三：手势耗时
        public Task<bool> DispatchGesture(string gestureStr, int duration);
        //执行多个手势
        // 参数二：执行手势坐标位， 以"/"分割手势时长、横纵和坐标 "\n"分割坐标点。"\r\n"分割多个手势
        public Task<bool> DispatchGestures(string gestures);
        //发送文本
        // 参数二：文本内容
        public Task<bool> SendKeys(string text);
        //返回
        public Task<bool> Back();
        //home
        public Task<bool> Home();
        //最近任务列表
        public Task<bool> Recents();
        //打开 开/关机 对话框
        public Task<bool> PowerDialog();
        //发送按键
        // 参数二：虚拟键值 按键对照表 https://blog.csdn.net/yaoyaozaiye/article/details/122826340
        public Task<bool> SendVk(int vk);
        //启动App
        // 参数二：启动APP的名称或者包名
        //非Aibote界面时候调用，需要开启悬浮窗
        public Task<bool> StartApp(string name);
        //判断app是否正在运行(包含前后台)
        // 参数二：启动APP的名称或者包名
        public Task<bool> AppIsRunnig(string name);
        //获取已安装app的包名(不包含系统APP)
        public Task<string> GetInstalledPackages();
        //屏幕大小
        public Task<(int width, int height)> GetWindowSize();
        //图片大小
        public Task<string> GetImageSize(string imgPath);
        //获取安卓ID
        public Task<string> GetAndroidId();
        //获取投屏组号
        public Task<string> GetGroup();
        //获取投屏编号
        public Task<string> GetIdentifier();
        //获取投屏标题
        public Task<string> GetTitle();
        //初始化ocr
        //使用AiboteAndroidOcr.exe ocr服务端
        public Task<bool> InitOcr(string serverIp, int prot = 9527);
        //使用ocr
        public Task<List<PositionConnent>> Ocr(int left = 0, int top = 0, int right = 0, int bottom = 0,
        int thresholdType = 0, int thresh = 0, int maxval = 0, double scale = 1.0);
        //URL请求
        public Task<string> UrlRequest(string url, string method, string headers, string postData);
        //Toast消息提示
        public Task<bool> ShowToast(string text, int duration);
        //识别验证码
        public Task<GetCaptchaModel> GetCaptcha(string imgPath, string userName, string password, string softId, string codeType, int lenMin = 0);
        //识别报错返分
        public Task<ErrorCaptchaModel> ErrorCaptcha(string userName, string password, string softId, string picId);
        //查询验证码剩余题分
        public Task<ScoreCaptchaModel> ScoreCaptcha(string userName, string password);
        //获取元素位置
        public Task<Region> GetElementRect(string xpath);
        //获取元素描述内容
        public Task<string> GetElementDescription(string xpath);
        //获取元素文本
        public Task<string> GetElementText(string xpath);
        //设置元素文本
        public Task<bool> SetElementText(string xpath);
        //点击元素
        public Task<bool> ClickElement(string xpath);
        //滚动元素
        public Task<bool> ScrollElement(string xpath, int direction);
        //判断元素是否存在
        public Task<bool> ExistsElement(string xpath);
        //判断元素是否选中
        public Task<bool> IsSelectedElement(string xpath);
        //上传文件
        //fileData 文件字节数据
        public Task<bool> PushFile(string filePath, byte[] bytes);
        //拉取文件
        public Task<byte[]> PullFile(string androidFilePath, string pcSavePath);
        //写入安卓文件
        public Task<bool> WriteAndroidFile(string androidFilePath, string writeText, bool isAppend);
        //读取安卓文件
        public Task<string> ReadAndroidFile(string androidFilePath);
        //删除安卓文件
        public Task<bool> DeleteAndroidFile(string androidFilePath);
        //判断文件是否存在
        public Task<bool> ExistsAndroidFile(string androidFilePath);
        //获取文件夹内的所有文件(不包含深层子目录)//获取文件夹内的所有文件(不包含深层子目录)
        public Task<string[]> GetAndroidSubFiles(string androidPath);
        //创建安卓文件夹
        public Task<bool> MakeAndroidDir(string androidPath);
        //跳转uri，在Aibote界面或者开启悬浮窗才有效
        public Task<bool> StartActivity(string activity, string uri = "", string packageName = "", string className = "", string type = "");
        //拨打电话
        public Task<bool> CallPhone(string phone);
        //发送短信
        public Task<bool> SendMsg(string phone, string msg);
        //获取活动窗口(activity)
        public Task<string> GetActivity();
        //获取活动包名(package)
        public Task<string> Package();
        //设置剪切板文本
        public Task<bool> SetClipboardText(string text);
        //获取剪切板文本
        public Task<string> GetClipboardText();
        //创建TextView控件
        public Task<bool> CreateTextView(int id, string hintText, int x, int y, int width, int height);
        //创建EditText控件
        public Task<bool> CreateEditText(int id, string hintText, int x, int y, int width, int height);
        //创建CheckBox控件
        public Task<bool> CreateCheckBox(int id, string hintText, int x, int y, int width, int height, bool isSelect);
        //创建ListText控件
        //","分割列表项
        public Task<bool> CreateListText(int id, string hintText, int x, int y, int width, int height, string items);
        //创建WebView控件
        public Task<bool> CreateWebView(int id, string url, int x, int y, int width, int height);
        //清除脚本控件
        public Task<bool> ClearScriptControl();
        //获取脚本配置参数
        public Task<string> GetScriptParam();
        //初始化Accessory。此函数需要配合WindowsBot.initHid 进行hid数据交换，具体封装请参考node.js AndroidBot initHid 函数
        /*hid触屏实际上是由windowsBot 通过数据线直接发送命令给安卓系统并执行，并非aibote.apk执行的命令。
        我们应当将所有设备插上数据线，安装驱动 准备就绪再调用此函数初始化。
        initHid函数调用 Windows initHid 和 android initAccessory函数， 初始化目的是两者的数据交换，并告知windowsBot发送命令给哪台安卓设备
        由于安卓自动化是 多设备、多线程，AndroidBot触屏相关函数发送指令给windowsBot立即返回， windwosDriver.exe则 存放到执行队列再按照顺序执行，所以触屏函数的返回值没有任何意义*/
        public Task<bool> InitAccessory();
        //获取手机旋转角度
        public Task<int> GetRotationAngle();
        //关闭连接
        public Task<bool> CloseDriver();
        //取得活动包名
        public Task<string> GetPackage();

    }
}
