//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

//namespace AiboteDotNet.WebBot
//{
//    public interface IWebBotCore
//    {
//        //查找句柄
//        // 参数一：函数名称
//        // 参数二：窗口类名
//        // 参数三：窗口名
//        //发送数据包：10/9/10\nfindWindowclassNamewindowNmae
//        //返回数据包：成功"65862"，失败 "null"
//        public Task<int> FindWindow(string className, string windowName);


//        //查找句柄数组
//        // 参数一：函数名称
//        // 参数二：窗口类名
//        // 参数三：窗口名
//        //发送数据包：11/9/10\nfindWindowsclassNamewindowNmae
//        //返回数据包：成功返回多个句柄"65862|65863|65864"，失败 "null"
//        public Task<int[]> FindWindows(string className, string windowName);


//        //查找子句柄
//        // 参数一：函数名称
//        // 参数二：当前窗口句柄
//        // 参数三：窗口类名
//        // 参数四：窗口名
//        //发送数据包：13/5/9/10\nfindSubWindow65862classNamewindowNmae
//        //返回数据包：成功"460538"，失败 "null"
//        public Task<int> FindSubWindow(int winHandle, string className, string windowName);


//        //查找父句柄
//        // 参数一：函数名称
//        // 参数二：当前窗口句柄
//        //发送数据包：16/6/\nfindParentWindow460538
//        //返回数据包：成功"65862"，失败 "null"
//        public Task<int> FindParentWindow(int winHandle);


//        //查找桌面窗口句柄
//        // 参数一：函数名称
//        //发送数据包：17/\nfindDesktopWindow
//        //返回数据包：成功"100011"，失败 "null"
//        public Task<int> FindDesktopWindow();


//        //获取窗口名称
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        //发送数据包：13/5\ngetWindowName65862
//        //返回数据包：成功"aibote"，失败 "null"
//        public Task<string> GetWindowName(int winHandle);


//        //显示/隐藏窗口
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：显示窗口 true， 隐藏窗口 false
//        //发送数据包：10/5/4\nshowWindow65862true
//        //返回数据包："false"或者 "true"
//        public Task<bool> ShowWindow(int winHandle, bool showWindows);


//        //设置窗口到最顶层
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：是否置顶
//        //发送数据包：12/5/4\nsetWindowTop65862true
//        //返回数据包："false"或者 "true"
//        public Task<bool> SetWindowTop(int winHandle, bool isTop);


//        //获取窗口位置
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        //发送数据包：12/5\ngetWindowPos65862
//        //返回数据包："239|628|989|764"
//        public Task<int[]> GetWindowPos(int winHandle);


//        //设置窗口位置
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三 整型，左上角横坐标
//        // 参数四 整型，左上角纵坐标
//        // 参数五 整型，窗口宽度
//        // 参数六 整型，窗口高度
//        //发送数据包：12/5/2/2/3/3\nsetWindowPos658621010200200
//        //返回数据包："false"或者 "true"
//        public Task<bool>   setWindowPos(  65862, 10, 10, 200, 200);
       

////移动鼠标
//sendData("moveMouse", 65862, 100, 100, false, 0);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：x坐标
//        // 参数四：y坐标
//        // 参数五：操作模式
//        // 参数六：元素句柄
//        发送数据包：9/5/3/3/5/1\nmoveMouse65862100100false0
//        返回数据包："true"

////移动鼠标(相对坐标)
//sendData("moveMouseRelative", 65862, 100, 100, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：x坐标
//        // 参数四：y坐标
//        // 参数五：操作模式
//        发送数据包：17/5/3/3/5\nmoveMouseRelative65862100100false
//        返回数据包："true"

////滚动鼠标
//sendData("rollMouse", 65862, 100, 100, 10, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：x坐标
//        // 参数四：y坐标
//        // 参数五：鼠标滚动次数,负数下滚鼠标,正数上滚鼠标
//        // 参数六：操作模式
//        发送数据包：9/5/3/3/2/5\nrollMouse658621001002false
//        返回数据包："true"

////点击鼠标
//sendData("clickMouse", 65862, 100, 100, 1, false, 0);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：x坐标
//        // 参数四：y坐标
//        // 参数五：点击类型，单击左键:1 单击右键:2 按下左键:3 弹起左键:4 按下右键:5 弹起右键:6 双击左键:7 双击右键:8
//        // 参数六：操作模式
//        // 参数七：元素句柄
//        发送数据包：9/5/3/3/1/5/1\nclickMouse658621001001false0
//        返回数据包："true"

////发送文本
//sendData("sendKeys", "rpa");
//        // 参数一：函数名称
//        // 参数二：输入的文本
//        发送数据包：8/3\nsendKeysrpa
//        返回数据包："true"

////后台发送文本
//sendData("sendKeysByHwnd", 65862, "rpa");
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：输入的文本
//        发送数据包：14/5/3\nsendKeysByHwnd65862rpa
//        返回数据包："true"

////输入虚拟键值(VK)
//sendData("sendVk", 13, 1);
//        // 参数一：函数名称
//        // 参数二：虚拟键值 回车对应 VK键值 13
//        // 参数三：输入类型，按下弹起:1 按下:2 弹起:3
//        发送数据包：6/2/1\nsendVk131
//        返回数据包："true"

////后台输入虚拟键值(VK)
//sendData("sendVkByHwnd", 65862, 13, 1);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：虚拟键值 回车对应 VK键值 13
//        // 参数四：输入类型，按下弹起:1 按下:2 弹起:3
//        发送数据包：12/5/2/1\nsendVkByHwnd65862131
//        返回数据包："true"

////截图保存
//sendData("saveScreenshot", 65862, "d:/1.png", 80, 150, 30, 30, 0, 127, 255, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：保存的图片路径（手机）
//        // 参数四：矩形左上角x坐标
//        // 参数五：矩形左上角y坐标
//        // 参数六：矩形右下角x坐标
//        // 参数七：矩形右下角y坐标
//        // 参数八：二值化算法类型
//        // 参数九：二值化阈值
//        // 参数十：二值化最大值
//        // 参数十一：前后台截图
//        发送数据包：14/5/8/2/3/2/2/1/3/3/5\nsaveScreenshot65862d:/1.png8015030300127255false
//        返回数据包："false"或者 "true"

////获取色值
//sendData("getColor", 65862, 100, 200, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：x坐标
//        // 参数四：y坐标
//        // 参数五：前后台获取颜色值
//        数据包：8/5/3/3/5\ngetColor65862100200false
//        返回数据包：#000000

////找图
//sendData("findImage", 65862, "d:/1.png", 0, 0, 0, 0, 0.95, 0, 0, 0, 1, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄或者图片路径
//        // 参数三：图片路径，多张小图查找应当用"|"分开小图路径
//        // 参数四：矩形左上角x坐标
//        // 参数五：矩形左上角y坐标
//        // 参数六：矩形右下角x坐标
//        // 参数七：矩形右下角y坐标
//        // 参数八：相似度
//        // 参数九：二值化算法类型
//        // 参数十：二值化阈值
//        // 参数十一：二值化最大值
//        // 参数十二：多个坐标点
//        // 参数十三：前后台找图
//        数据包：9/5/8/1/1/1/1/4/1/1/1/1/5\nfindImage65862d:/1.png00000.950001false
//        返回数据包：单坐标点成功"x|y"  多坐标点成功 "x1|y1/x2|y2..."  失败"-1|-1"

////找动态图
//sendData("findAnimation", 65862, 100, 0, 0, 0, 0, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：前后两张图相隔的时间，单位毫秒
//        // 参数四：矩形左上角x坐标
//        // 参数五：矩形左上角y坐标
//        // 参数六：矩形右下角x坐标
//        // 参数七：矩形右下角y坐标
//        // 参数八：前后台找动态图
//        数据包：13/5/3/0/0/0/0/5\nfindAnimation658621000000false
//        返回数据包：单坐标点成功"x|y"  多坐标点成功 "x1|y1/x2|y2..."  失败"-1|-1"

////找色
//sendData("findColor", 65862, "#e8f2f8", "10/20/#e7f0f7", 0, 0, 0, 0, 1, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：主颜色值
//        // 参数四：相对偏移的颜色点，以 "x坐标+y坐标+色值" 字符串形式
//        // 参数五：矩形左上角x坐标
//        // 参数六：矩形左上角y坐标
//        // 参数七：矩形右下角x坐标
//        // 参数八：矩形右下角y坐标
//        // 参数九：相似度
//        // 参数十：前后台找色
//        数据包：9/5/7/13/1/1/1/1/1/5\nfindColor65862#e8f2f810/20/#e7f0f700001false
//返回数据包：成功"x|y" 失败"-1|-1"

////比色
//sendData("compareColor", 65862, 100, 200, "#e8f2f8", "10/20/#e7f0f7", 0, 0, 0, 0, 1, false);
//        // 参数一：函数名称
//        // 参数二：窗口句柄
//        // 参数三：主颜色值所在的X坐标
//        // 参数四：主颜色值所在的Y坐标
//        // 参数五：主颜色值
//        // 参数六：相对偏移的颜色点，以 "x坐标+y坐标+色值" 字符串形式
//        // 参数七：矩形左上角x坐标
//        // 参数八：矩形左上角y坐标
//        // 参数九：矩形右下角x坐标
//        // 参数十：矩形右下角y坐标
//        // 参数十一：相似度
//        // 参数十二：前后台比色
//        数据包：12/5/3/3/7/11/1/1/1/1/1/5\ncompareColor65862100200#e8f2f810/20/#e7f0f700001false
//返回数据包："false"或者 "true"

////初始化ocr
//sendData("initOcr", "127.0.0.1", 9752);
//        数据包：7/9/4\ninitOcr127.0.0.19752
//返回数据包："false"或者 "true"

////使用ocr
//sendData("ocr", 65862,  0, 0, 0, 0, 0, 0, 0, false);
//        数据包：3/5/1/1/1/1/1/1/1/5\nocr658620000000false
//        返回数据包：'[[[[53.0, 43.0], [340.0, 40.0], [340.0, 85.0], [54.0, 88.0]], ["下午24 7", 0.82231205701828]], [[[75.0, 238.0], [223.0, 238.0], [223.0, 315.0], [75.0, 315.0]], ["标", 0.9653342366218567]], [[[72.0, 380.0], [303.0, 375.0], [304.0, 427.0], [74.0, 433.0]], ["写或", 0.8716280460357666]], [[[347.0, 385.0], [602.0, 385.0], [602.0, 428.0], [347.0, 428.0]], ["创建思维笔记", 0.8633089661598206]]]'

////ocrByFile
//sendData("ocrByFile", "d:/1.png",  0, 0, 0, 0, 0, 0, 0);
//        数据包：9/8/1/1/1/1/1/1/1\nocrByFiled:/1.png0000000
//        返回数据包：'[[[[53.0, 43.0], [340.0, 40.0], [340.0, 85.0], [54.0, 88.0]], ["下午24 7", 0.82231205701828]], [[[75.0, 238.0], [223.0, 238.0], [223.0, 315.0], [75.0, 315.0]], ["标", 0.9653342366218567]], [[[72.0, 380.0], [303.0, 375.0], [304.0, 427.0], [74.0, 433.0]], ["写或", 0.8716280460357666]], [[[347.0, 385.0], [602.0, 385.0], [602.0, 428.0], [347.0, 428.0]], ["创建思维笔记", 0.8633089661598206]]]'

////获取指定元素名称
//sendData("getElementName", 65862, "Window/Text");
//        数据包：14/5/11\ngetElementName65862Window/Text
//        返回数据包："aibote is pure code RPA"

////获取指定元素文本
//sendData("getElementValue", 65862, "Window/Edit");
//        数据包：15/5/11\ngetElementValue65862Window/Edit
//        返回数据包："aibote RPA"

////获取指定元素矩形大小
//sendData("getElementRect", 65862, "Window/Button");
//        数据包：14/5/13\ngetElementRect65862Window/Button
//        返回数据包："239|628|989|764"

////获取指定元素窗口句柄
//sendData("getElementWindow", 65862, "Window/Button");
//        数据包：16/5/13\ngetElementWindow65862Window/Button
//        返回数据包："460538"

////点击元素
//sendData("clickElement", 65862, "Window/Button", 1);
//        数据包：12/5/13/1\nclickElement65862Window/Button1
//        返回数据包："false"或者 "true"

////执行元素默认操作(一般是点击操作)
//sendData("invokeElement", 65862, "Window/Button");
//        数据包：13/5/13\ninvokeElement65862Window/Button
//        返回数据包："false"或者 "true"

////设置指定元素作为焦点
//sendData("setElementFocus", 65862, "Window/Button");
//        数据包：15/5/13\nsetElementFocus65862Window/Button
//        返回数据包："false"或者 "true"

////设置元素文本
//sendData("setElementValue", 65862, "Window/Button", "rpa");
//        数据包：15/5/13/3\nsetElementValue65862Window/Buttonrpa
//        返回数据包："false"或者 "true"

////滚动元素
//sendData("setElementScroll", 65862, "Window", -1, 0.1);
//        数据包：16/5/6/2/3\nsetElementScroll65862Window-10.1
//返回数据包："false"或者 "true"

////单/复选框是否选中
//sendData("isSelected", 65862, "Window/CheckBox");
//        数据包：10/5/15\nisSelected65862Window/CheckBox
//        返回数据包：未找到元素返回"false" 选中返回"selected" 未选中返回 "unselected"

////关闭窗口
//sendData("closeWindow", 65862, "Window");
//        数据包：11/5/6\ncloseWindow65862Window
//        返回数据包："false"或者 "true"

////设置窗口状态
//sendData("setWindowState", 65862, "Window", 2);
//        数据包：14/5/6/1\nsetWindowState65862Window2
//        返回数据包："false"或者 "true"

////设置剪切板文本
//sendData("setClipboardText", "rpa");
//        数据包：16/3\nsetClipboardTextrpa
//        返回数据包："false"或者 "true"

////获取剪切板文本
//sendData("getClipboardText");
//        数据包：16\ngetClipboardText
//        返回数据包："rpa"

////启动指定程序
//sendData("startProcess", "cmd", true, false);
//        数据包：12/3/4/5\nstartProcesscmdtruefalse
//        返回数据包："false"或者 "true"

////执行cmd命令
//sendData("executeCommand", "ipconfig", 300);
//        数据包：14/8/3\nexecuteCommandipconfig300
//        返回数据包：返回cmd执行结果

//        //指定url下载文件
//        sendData("downloadFile", "http://www.gogo.com/rpa.rar", "d:/rpa.rar", true);
//        数据包：12/27/10/4\ndownloadFilehttp://www.gogo.com/rpa.rard:/rpa.rartrue
//返回数据包："true"

////打开excle
//sendData("openExcel", "D:/rpa.xlsx");
//        数据包：9/11\nopenExcelD:/rpa.xlsx
//        返回数据包："null"或者 {"book":"088173SDFU13","path":"D:/rpa.xlsx"}

//    //打开excel表格
//    sendData("openExcelSheet", "088173SDFU13", "D:/rpa.xlsx", "sheet1");
//    数据包：14/12/11/6\nopenExcelSheet088173SDFU13D:/rpa.xlsxsheet1
//    返回数据包："null"或者 "A123HHI123F132"

////保存/关闭excel
//sendData("saveExcel", "088173SDFU13", "D:/rpa.xlsx");
//    数据包：9/12/11\nsaveExcel088173SDFU13D:/rpa.xlsx
//    返回数据包："false"或者 "true"

////写入数字到表格
//sendData("writeExcelNum", "A123HHI123F132", 0, 0, 123);
//    数据包：13/14/1/1/3\nwriteExcelNumA123HHI123F13200123
//    返回数据包："false"或者 "true"

////写入字符串到表格
//sendData("writeExcelStr", "A123HHI123F132", 0, 0, "rpa");
//    数据包：13/14/1/1/3\nwriteExcelStrA123HHI123F13200rpa
//    返回数据包："false"或者 "true"

////读取excel表格数字
//sendData("readExcelNum", "A123HHI123F132", 0, 0);
//    数据包：12/14/1/1\nreadExcelNumA123HHI123F13200
//    返回数据包：123

////读取excel表格字串
//sendData("readExcelStr", "A123HHI123F132", 0, 0);
//    数据包：12/14/1/1\nreadExcelStrA123HHI123F13200
//    返回数据包："rpa"

//删除excel表格行
//sendData("removeExcelRow",  0, 0);
//    数据包：14/1/1\nremoveExcelRow00
//    返回数据包："false"或者 "true"

//删除excel表格列
//sendData("removeExcelCol", 0, 0);
//    数据包：14/1/1\nremoveExcelCol00
//    返回数据包："false"或者 "true"

//提取视频帧
//setSendData("extractImageByVideo", "d:/video/test.mp4", "d:/video", 1);
//    数据包：19/17/8/1\nextractImageByVideod:/video/test.mp4d:/video1
//    返回数据包："false"或者 "true"

//裁剪图片
//setSendData("cropImage", "d:/image/src.jpg", "d:/image/dest.jpg", 0, 0, 10, 10);
//    数据包：9/16/17/1/1/2/2\ncropImaged:/image/src.jpgd:/image/dest.jpg001010
//    返回数据包："false"或者 "true"

//初始化NLP
//sendData("initNLP", "xxxaOS3Z8xxRvbJv2qA7VcLxxBlxxxJxxnZvmfLMxTUcnx8DLx6");
//    数据包：7/51\ninitNLPxxxaOS3Z8xxRvbJv2qA7VcLxxBlxxxJxxnZvmfLMxTUcnx8DLx6
//返回数据包："false"或者 "true"

//chatGpt
//sendData("chatgpt", "text-davinci-003", "hello！", 256, 0.7, "");
//数据包：7/16/6/3/3/0\nchatgpttext-davinci-003hello!2560.7
//返回数据包：'{text:"你好", finish:true}'

//chatgptEdit
//sendData("chatgptEdit", "text-davinci-edit-001", "hella", "修正错误文字", 256, 1);
//数据包：11/21/5/18/3/1\nchatgptEdittext-davinci-edit-001hella修正错误文字2561
//返回数据包：'{text:"hello", finish:true}'

//创建微调模型
//sendData("createFineTune", "fileId", "davinci", "aiboteRPA");
//数据包：14/6/7/9\ncreateFineTunefileIddavinciaiboteRPA
//返回数据包：成功返回微调id，失败返回null

//列出所有微调信息
//sendData("listFineTunes");
//数据包：13\nlistFineTunes
//返回数据包：成功返回"{[{baseModel, object, fineTuneId, fineTunedModel, fineTuneStatus, fileName:string, fileId, fileStatus}, ...]}"，失败返回"null"

//获取指定微调id的详细信息
//sendData("listFineTune", "ft-xxxxxxxx");
//数据包：12/11\nlistFineTunefd-xxxxxxxx
//返回数据包：成功返回"{{baseModel, object, fineTuneId, fineTunedModel, fineTuneStatus, fileName:string, fileId, fileStatus}}"，失败返回"null"

//取消正在微调的作业
//sendData("cancelFineTune", "ft-xxxxxxxx");
//数据包：14/11\ncancelFineTunefd-xxxxxxxx
//返回数据包："false"或者 "true"

//删除微调模型
//sendData("deleteFineTuneModel", "ft-xxxxxxxx");
//数据包：19/11\ndeleteFineTuneModelfd-xxxxxxxx
//返回数据包："false"或者 "true"

//上传训练文件到服务器
//sendData("uploadTrainFile", "d:/test.jsonl");
//数据包：15/13\nuploadTrainFiled:/test.jsonl
//返回数据包：成功返回"fileIdxxxxxxxxx"，失败返回"null"

//列出所有训练文件信息
//sendData("listTrainFiles");
//数据包：14\nlistTrainFiles
//返回数据包：成功返回"[{bytes, fileName, fileId, purpose}]" 失败返回"null"

//列出指定id的文件信息
//sendData("listTrainFile", "fileIdxxxxxxxxx");
//数据包：13/15\nlistTrainFilefileIdxxxxxxxxx
//返回数据包：成功返回"{bytes, fileName, fileId, purpose}" 失败返回"null"

//下载训练文件内容
//sendData("downloadTrainFile", "fileIdxxxxxxxxx");
//数据包：17/15\ndownloadTrainFilefileIdxxxxxxxxx
//返回数据包：成功返回文件内容，失败返回"null"

//删除训练文件
//sendData("deleteTrainFile", "fileIdxxxxxxxxx");
//数据包：15/15\ndeleteTrainFilefileIdxxxxxxxxx
//返回数据包："false"或者 "true"

//激活语音服务(不支持win 7系统)
//setSendData("activateSpeechService", "xxxxxxxxxxxxxxxx");
//数据包：21/16\nactivateSpeechServicexxxxxxxxxxxxxxxx
//返回数据包："false"或者 "true"

//初始化语音服务(不支持win 7系统)，需要调用 activateSpeechService 激活
//setSendData("initSpeechService", "4:714d4ie62639d1211351f65956621", "eastus");
//数据包：17/31/6\ninitSpeechService4:714d4ie62639d:2;;35;f65956621eastus
//返回数据包："false"或者 "true"

//音频文件转文本
//setSendData("audioFileToText", "d:/test.wav", "zh-cn");
//数据包：15/11/5\naudioFileToTextd:/test.wavzh-cn
//返回数据包：成功返回 "Aibote 是一款非常优秀的自动化框架"，失败返回"null"

//麦克风输入流转换文本
//setSendData("microphoneToText", "zh-cn");
//数据包：16/5\nmicrophoneToTextzh-cn
//返回数据包：成功返回 "Aibote 是一款非常优秀的自动化框架"，失败返回"null"

//文本合成音频到扬声器
//setSendData("textToBullhorn", "hello", "zh-cn", "zh-cn-XiaochenNeural");
//数据包：14/5/5/20\ntextToBullhornhellozh-cnzh-cn-XiaochenNeural
//返回数据包："false"或者 "true"

//文本合成音频并保存到文件
//setSendData("textToAudioFile", "d:/test.ssml", "zh-cn", "zh-cn-XiaochenNeural", "d:/test.wav");
//数据包：15/12/5/20/11\ntextToAudioFiled:/test.ssmlzh-cnzh-cn-XiaochenNeurald:/test.wav
//返回数据包："false"或者 "true"

//麦克风音频翻译成目标语言文本
//setSendData("microphoneTranslationText", "zh-cn", "en-US");
//数据包：25/5/5\nmicrophoneTranslationTextzh-cnen-US
//返回数据包：成功返回"Aibote is an excellent automation framework"，失败返回"null"

//音频文件翻译成目标语言文本
//setSendData("audioFileTranslationText", "d:/test.wav", "zh-cn", "en-US");
//数据包：24/11/5/5\naudioFileTranslationTextd:/test.wavzh-cnen-US
//返回数据包：成功返回"Aibote is an excellent automation framework"，失败返回"null"

//初始化数字人
//setSendData("initMetahuman", "D:/AiboteMetahuman/metahumanMode", 1.0, false);
//数据包：13/32/3/5\ninitMetahumanD:/AiboteMetahuman/metahumanMode1.0false
//返回数据包："false"或者 "true"

//数字人说话，此函数需要调用 initSpeechService 初始化语音服务
//setSendData("metahumanSpeech", "D:/AiboteMetahuman/voice", "Aibote is an excellent automation framework", "zh-cn", "zh-cn-XiaochenNeural", 0, true, 0, "General");
//数据包：15/24/43/5/20/1/4/1/7\nmetahumanSpeechD:/AiboteMetahuman/voiceAibote is an excellent automation frameworkzh-cnzh-cn-XiaochenNeural0true0General
//返回数据包："false" 或者 说话时长"13536"

//数字人说话缓存模式，需要调用 initSpeechService 初始化语音服务。函数一般用于常用的话术播报，非常用话术切勿使用，否则内存泄漏
//setSendData("metahumanSpeechCache", "D:/AiboteMetahuman/voice", "Aibote is an excellent automation framework", "zh-cn", "zh-cn-XiaochenNeural", 0, true, 0, "General");
//数据包：20/24/43/5/20/1/4/1/7\nmetahumanSpeechCacheD:/AiboteMetahuman/voiceAibote is an excellent automation frameworkzh-cnzh-cn-XiaochenNeural0true0General
//返回数据包："false"或者 "true" 或者 说话时长"13536"

//插入视频到数字人，此函数依赖 initMetahuman函数运行，否则程序会崩溃
//setSendData("metahumanInsertVideo", "C:/Users/wenbaobao/Desktop/voide.mp4", "C:/Users/wenbaobao/Desktop/audio.wav", true);
//数据包：20/36/36/4\nmetahumanInsertVideoC:/Users/wenbaobao/Desktop/voide.mp4C:/Users/wenbaobao/Desktop/audio.wavtrue
//返回数据包："false"或者 "true"

//生成数字人短视频，此函数依赖 initMetahuman函数运行，否则程序会崩溃
//setSendData("makeMetahumanVideo", "d:", "Aibote数字人生成短视频", "zh-cn", "zh-cn-XiaochenNeural", bgFilePath = "", simValue = 0, "General", quality = 0, speechRate = 0);
//18/2/40/5/20/0/1/7/1/1\nmakeMetahumanVideod:Aibote数字人生成短视频zh-cnzh-cn-XiaochenNeural0General00
//返回数据包："false"或者 说话时长"13536"

//替换数字人背景，此函数依赖 initMetahuman函数运行，否则程序会崩溃
//setSendData("replaceBackground", "D:/1.jpg", -1, -1, -1, 50);
//数据包：17/8/2/2/2/2\nreplaceBackgroundD:/1.jpg-1-1-150
//返回数据包："true"

//显示数字人说话的文本，此函数依赖 initMetahuman函数运行，否则程序会崩溃
//setSendData("showSpeechText", 0, "Arial", 30, 128, 255, 0, false, false);
//数据包：14/1/5/2/3/3/1/5/5\nshowSpeechText0Arial301282550falsefalse
//返回数据包："true"

////获取驱动程序命令行参数(不包含ip和port)
//sendData("getExtendParam");
//发送数据包：14\ngetExtendParam
//返回数据包："extendParam1 extendParam2"

////初始化hid，此函数需要配合AndroidBot.initAccessory 进行hid数据交换，具体封装请参考node.js AndroidBot initHid 函数
///*hid触屏实际上是由windowsBot 通过数据线直接发送命令给安卓系统并执行，并非aibote.apk执行的命令。
//我们应当将所有设备插上数据线，安装驱动 准备就绪再调用此函数初始化。
//initHid函数调用 Windows initHid 和 android initAccessory函数， 初始化目的是两者的数据交换，并告知windowsBot发送命令给哪台安卓设备
//由于安卓自动化是 多设备、多线程，AndroidBot触屏相关函数发送指令给windowsBot立即返回， windwosDriver.exe则 存放到执行队列再按照顺序执行，所以触屏函数的返回值没有任何意义*/
//sendData("initHid");
//数据包：7\ninitHid
//返回数据包："false"或者 "true"

////获取Hid相关数据，具体封装请参考node.js AndroidBot initHid 函数
//sendData("getHidData");
//数据包：10\ngetHidData
//返回数据包："androidId1|androidId2|androidId3"

////按下
//sendData("hidPress", "1f73c8f2f3b2f108", 0, 100, 200);
//数据包：8/16/1/3/3\nhidPress1f73c8f2f3b2f0100200
//返回数据包："void"

////移动
//sendData("hidMove", "1f73c8f2f3b2f108", 0, 100, 200, 3000);
//数据包：7/16/1/3/3/4\nhidMove1f73c8f2f3b2f01002003000
//返回数据包："void"

////释放
//sendData("hidRelease", "1f73c8f2f3b2f108", 0);
//数据包：10/16/1\nhidRelease1f73c8f2f3b2f0
//返回数据包："void"

////单击
//sendData("hidClick", "1f73c8f2f3b2f108", 0, 100, 200);
//数据包：8/16/1/3/3\nhidClick1f73c8f2f3b2f0100200
//返回数据包："void"

////双击
//sendData("hidDoubleClick", "1f73c8f2f3b2f108", 0, 100, 200);
//数据包：14/16/1/3/3\nhidDoubleClick1f73c8f2f3b2f0100200
//返回数据包："void"

////长按
//sendData("hidLongClick", "1f73c8f2f3b2f108", 0, 100, 200, 3000);
//数据包：12/16/1/3/3/4\nhidLongClick1f73c8f2f3b2f01002003000
//返回数据包："void"

////滑动
//sendData("hidSwipe", "1f73c8f2f3b2f108", 0, 100, 200, 300, 500, 3000);
//数据包：8/16/1/3/3/3/3/4\nhidSwipe1f73c8f2f3b2f01002003005003000
//返回数据包："void"

////执行手势
//sendData("hidDispatchGesture", "1f73c8f2f3b2f108", 0, "1000/1558\n100/100\n799/800\n234/89", 3000);
//// 参数一：函数名称
//// 参数二：手机旋转角度
//// 参数三：安卓id
//// 参数四：执行手势坐标位， 以"/"分割横纵坐标 "\n"分割坐标点。注意：末尾坐标点没有\n结束
//// 参数五：手势耗时
//数据包：18/16/1/35/4\nhidDispatchGesture1f73c8f2f3b2f01000/1558\n100/100\n799/800\n234/893000
//返回数据包："void"

////执行多个手势
//sendData("hidDispatchGestures", "1f73c8f2f3b2f108", 0, "1000/100/100\n200/200\r\n2000/300/300\n500/500");
//// 参数一：函数名称
//// 参数二：手机旋转角度
//// 参数三：安卓id
//// 参数四：执行手势坐标位， 以"/"分割手势时长、横纵和坐标 "\n"分割坐标点。"\r\n"分割多个手势
//数据包：19/16/1/46\nhidDispatchGestures1f73c8f2f3b2f01000/100/100\n200/200\r\n2000/300/300\n500/500
//返回数据包："void"

////关闭驱动程序
//sendData("closeDriver");
//发送数据包：11\ncloseDriver
//    }
//}
