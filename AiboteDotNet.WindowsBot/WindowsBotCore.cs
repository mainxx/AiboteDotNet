using AiboteDotNet.Core.DataModel;
using AiboteDotNet.Core.Tcp;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AiboteDotNet.WindowsBot
{
    public class WindowsBotCore : IWindowsBotCore
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public TcpChannel Channel { get; set; }

        public WindowsBotCore(TcpChannel tcpChannel)
        {
            Channel = tcpChannel;
        }
        public Task<bool> ActivateSpeechService(string activateKey)
        {
            return Channel.SendData<bool>("activateSpeechService", activateKey);
        }

        public Task<string> AudioFileToText(string filePath, string language)
        {
            return Channel.SendData<string>("audioFileToText", filePath, language);
        }

        public Task<string> AudioFileTranslationText(string audioPath, string sourceLanguage, string targetLanguage)
        {
            return Channel.SendData<string>("audioFileTranslationText", audioPath, sourceLanguage, targetLanguage);
        }

        public Task<bool> CancelFineTune(string fineTuneId)
        {
            return Channel.SendData<bool>("cancelFineTune", fineTuneId);
        }

        public Task<string> Chatgpt(string model, string promptOrMessages, string maxTokens, string temperature, string stop = "")
        {
            return Channel.SendData<string>("chatgpt", model, promptOrMessages, maxTokens, temperature, stop);
        }

        public Task<string> ChatgptEdit(string model, string input, string instruction, int maxTokens, int temperature)
        {
            return Channel.SendData<string>("chatgptEdit", model, input, instruction, maxTokens, temperature);
        }

        public Task<bool> ClickElement(int hwnd, string xpath, int clickType = 1)
        {
            return Channel.SendData<bool>("clickElement", hwnd, xpath, clickType);
        }

        public Task<bool> ClickMouse(int hwnd, int x, int y, int clickType, bool opMode, int elementHandle)
        {
            return Channel.SendData<bool>("clickMouse", hwnd, x, y, clickType, opMode, elementHandle);
        }

        public Task<string> CloseDriver()
        {
            return Channel.SendData<string>("closeDriver");
        }

        public Task<bool> CloseWindow(int hwnd, string xpath)
        {
            return Channel.SendData<bool>("closeWindow", hwnd, xpath);
        }

        public Task<bool> CompareColor(int hwnd, int x, int y, string mainColor, string relativeColorStr,
            int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, double similarity, bool isbackground)
        {
            return Channel.SendData<bool>("compareColor", hwnd, x, y, mainColor, relativeColorStr,
                leftTopX, leftTopY, rightBottomX, rightBottomY, similarity, isbackground);
        }

        public Task<string> CreateFineTune(string fileId, string baseModel, string suffix)
        {
            return Channel.SendData<string>("createFineTune", fileId, baseModel, suffix);
        }

        public Task<bool> CropImage(string imagePath, string savePath, int left, int top, int rigth, int bottom)
        {
            return Channel.SendData<bool>("cropImage", imagePath, savePath, left, top, rigth, bottom);
        }

        public Task<bool> DeleteFineTuneModel(string fineTuneId)
        {
            return Channel.SendData<bool>("deleteFineTuneModel", fineTuneId);
        }

        public Task<bool> DeleteTrainFile(string fileId)
        {
            return Channel.SendData<bool>("deleteTrainFile", fileId);
        }

        public Task<bool> DownloadFile(string url, string filePath, bool isWait = true)
        {
            return Channel.SendData<bool>("downloadFile", url, filePath, isWait);
        }

        public Task<string> DownloadTrainFile(string fileId)
        {
            return Channel.SendData<string>("downloadTrainFile", fileId);
        }

        public Task<string> ExecuteCommand(string command, int waitTimeout = 300)
        {
            return Channel.SendData<string>("executeCommand", command, waitTimeout);
        }

        public Task<bool> ExtractImageByVideo(string videoPath, string saveFolder, string jumpFrame)
        {
            return Channel.SendData<bool>("extractImageByVideo", videoPath, saveFolder, jumpFrame);
        }

        public async Task<List<BotPoint>> FindAnimation(int hwnd, int interval, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, bool isbackground)
        {
            var data = await Channel.SendData<string>("findAnimation", hwnd, interval, leftTopX, leftTopY, rightBottomX, rightBottomY, isbackground);
            return BotPoint.ByList(data);
        }

        public async Task<BotPoint> FindColor(int hwnd, string mainColor, string relativeColorStr, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, double similarity, bool isbackground)
        {
            var data = await Channel.SendData<string>("findColor", hwnd, mainColor, relativeColorStr, leftTopX, leftTopY, rightBottomX, rightBottomY, similarity, isbackground);
            return BotPoint.By(data);
        }

        public Task<int> FindDesktopWindow()
        {
            return Channel.SendData<int>("findDesktopWindow");
        }

        public async Task<List<BotPoint>> FindImage(int hwnd, string imagePaths, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, double similarity, int AlgorithmType, int threshold, int maxValue, int isMultiple, bool isbackground)
        {
            var data = await Channel.SendData<string>("findImage", hwnd, imagePaths, leftTopX, leftTopY, rightBottomX, rightBottomY, similarity, AlgorithmType, threshold, maxValue, isMultiple, isbackground);
            return BotPoint.ByList(data);
        }

        public Task<int> FindParentWindow(int hwnd)
        {
            return Channel.SendData<int>("findParentWindow", hwnd);
        }

        public Task<int> FindSubWindow(int hwnd, string className, string windowName)
        {
            return Channel.SendData<int>("findParentWindow", hwnd, className, windowName);
        }

        public Task<int> FindWindow(string className, string windowName)
        {
            return Channel.SendData<int>("findWindow", className, windowName);
        }

        public Task<int[]> FindWindows(string className, string windowName)
        {
            return Channel.SendData<int[]>("findWindows", className, windowName);
        }

        public Task<string> GetClipboardText()
        {
            return Channel.SendData<string>("getClipboardText");
        }

        public Task<string> GetColor(int hwnd, int x, int y, bool isbackground)
        {
            return Channel.SendData<string>("getColor", hwnd, x, y, isbackground);
        }

        public Task<string> GetElementName(int hwnd, string xpath)
        {
            return Channel.SendData<string>("getElementName", hwnd, xpath);
        }

        public Task<string> GetElementRect(int hwnd, string xpath)
        {
            return Channel.SendData<string>("getElementRect", hwnd, xpath);
        }

        public Task<string> GetElementValue(int hwnd, string xpath)
        {
            return Channel.SendData<string>("getElementValue", hwnd, xpath);
        }

        public Task<string> GetElementWindow(int hwnd, string xpath)
        {
            return Channel.SendData<string>("getElementWindow", hwnd, xpath);
        }

        public Task<string> GetExtendParam()
        {
            return Channel.SendData<string>("getExtendParam");
        }

        public Task<string> GetHidData()
        {
            return Channel.SendData<string>("getHidData");
        }

        public Task<string> GetWindowName(int hwnd)
        {
            return Channel.SendData<string>("getWindowName", hwnd);
        }

        public Task<int[]> GetWindowPos(int hwnd)
        {
            return Channel.SendData<int[]>("getWindowPos", hwnd);
        }

        public Task<string> HidClick(string androidId, int type, int x, int y)
        {
            return Channel.SendData<string>("hidClick", androidId, type, x, y);
        }

        public Task<string> HidDispatchGesture(string androidId, int type, string pointStr, int duration)
        {
            return Channel.SendData<string>("hidDispatchGesture", androidId, type, pointStr, duration);
        }

        public Task<string> HidDispatchGestures(string androidId, int type, string pointStr)
        {
            return Channel.SendData<string>("hidDispatchGestures", androidId, type, pointStr);
        }

        public Task<string> HidDoubleClick(string androidId, int type, int x, int y)
        {
            return Channel.SendData<string>("hidDoubleClick", androidId, type, x, y);
        }

        public Task<string> HidLongClick(string androidId, int type, int x, int y, int duration)
        {
            return Channel.SendData<string>("hidLongClick", androidId, type, x, y, duration);
        }

        public Task<string> HidMove(string androidId, int type, int x, int y, int duration)
        {
            return Channel.SendData<string>("hidMove", androidId, type, x, y, duration);
        }

        public Task<string> HidPress(string androidId, int type, int x, int y)
        {
            return Channel.SendData<string>("hidPress", androidId, type, x, y);
        }

        public Task<string> HidRelease(string androidId, int type)
        {
            return Channel.SendData<string>("hidRelease", androidId, type);
        }

        public Task<string> HidSwipe(string androidId, int type, int beginX, int beginY, int endX, int endY, int duration)
        {
            return Channel.SendData<string>("hidSwipe", androidId, type, beginX, beginY, endX, endY, duration);
        }

        public Task<bool> InitHid()
        {
            return Channel.SendData<bool>("initHid");
        }

        public Task<bool> InitMetahuman(string metahumanModePath, string metahumanScaleValue, bool isUpdateMetahuman = false)
        {
            return Channel.SendData<bool>("initMetahuman", metahumanModePath, metahumanScaleValue, isUpdateMetahuman);
        }

        public Task<bool> InitNLP(string key)
        {
            return Channel.SendData<bool>("initNLP", key);
        }

        public Task<bool> InitOcr(string serverIp, int prot)
        {
            return Channel.SendData<bool>("initOcr", serverIp, prot);
        }

        public Task<bool> InitSpeechService(string speechKey, string speechRegion)
        {
            return Channel.SendData<bool>("initSpeechService", speechKey, speechRegion);
        }

        public Task<bool> InvokeElement(int hwnd, string xpath)
        {
            return Channel.SendData<bool>("invokeElement", hwnd, xpath);
        }

        public Task<bool> IsSelected(int hwnd, string xpath)
        {
            return Channel.SendData<bool>("isSelected", hwnd, xpath);
        }

        public Task<string> ListFineTune(string fineTuneId)
        {
            return Channel.SendData<string>("listFineTune", fineTuneId);
        }

        public Task<string> ListFineTunes()
        {
            return Channel.SendData<string>("listFineTunes");
        }

        public Task<bool> ListTrainFile(string fileId)
        {
            return Channel.SendData<bool>("listTrainFile", fileId);
        }


        public Task<string> ListTrainFiles()
        {
            return Channel.SendData<string>("listTrainFiles");
        }

        public Task<string> MakeMetahumanVideo(string saveVideoFolder, string text, string language, string voiceName, string bgFilePath, int simValue = 0, string voiceStyle = "General", int quality = 0, int speechRate = 0)
        {
            return Channel.SendData<string>("makeMetahumanVideo", saveVideoFolder, text, language, voiceName, bgFilePath, simValue, voiceStyle, quality, speechRate);
        }

        public Task<bool> MetahumanInsertVideo(string videoFilePath, string audioFilePath, bool waitPlayVideo = true)
        {
            return Channel.SendData<bool>("metahumanInsertVideo", videoFilePath, audioFilePath, waitPlayVideo);
        }

        public Task<string> MetahumanSpeech(string saveVoiceFolder, string text, string language, string voiceName, int quality = 0, bool waitPlaySound = true, int speechRate = 0, string voiceStyle = "General")
        {
            return Channel.SendData<string>("metahumanSpeech", saveVoiceFolder, text, language, voiceName, quality, waitPlaySound, speechRate, voiceStyle);
        }

        public Task<string> MetahumanSpeechCache(string saveVoiceFolder, string text, string language, string voiceName, int quality = 0, bool waitPlaySound = true, int speechRate = 0, string voiceStyle = "General")
        {
            return Channel.SendData<string>("metahumanSpeechCache", saveVoiceFolder, text, language, voiceName, quality, waitPlaySound, speechRate, voiceStyle);
        }

        public Task<string> MicrophoneToText(string language)
        {
            return Channel.SendData<string>("microphoneToText", language);
        }

        public Task<string> MicrophoneTranslationText(string sourceLanguage, string targetLanguage)
        {
            return Channel.SendData<string>("microphoneTranslationText", sourceLanguage, targetLanguage);
        }

        public Task<bool> MoveMouse(int hwnd, int x, int y, bool opMode, int elementHandle)
        {
            return Channel.SendData<bool>("moveMouse", hwnd, x, y, opMode, elementHandle);
        }

        public Task<bool> MoveMouseRelative(int hwnd, int x, int y, bool opMode)
        {
            return Channel.SendData<bool>("moveMouseRelative", hwnd, x, y, opMode);
        }

        public Task<string> Ocr(int hwnd, int left = 0, int top = 0, int right = 0, int bottom = 0, int thresholdType = 0, int thresh = 0, int maxval = 0, bool isBack = false)
        {
            return Channel.SendData<string>("ocr", hwnd, left, top, right, bottom, thresholdType, thresh, maxval, isBack);
        }

        public Task<string> OcrByFile(string savePath, int left = 0, int top = 0, int right = 0, int bottom = 0, int thresholdType = 0, int thresh = 0, int maxval = 0)
        {
            return Channel.SendData<string>("ocrByFile", savePath, left, top, right, bottom, thresholdType, thresh, maxval);
        }

        public Task<string> OpenExcel(string excelPath)
        {
            return Channel.SendData<string>("openExcel", excelPath);
        }

        public Task<string> OpenExcelSheet(string excelObject, string sheetName)
        {
            return Channel.SendData<string>("openExcelSheet", excelObject, sheetName);
        }

        public Task<string> ReadExcelNum(string sheetObject, int row, int col)
        {
            return Channel.SendData<string>("readExcelNum", sheetObject, row, col);
        }

        public Task<string> ReadExcelStr(string sheetObject, int row, int col)
        {
            return Channel.SendData<string>("readExcelStr", sheetObject, row, col);
        }

        public Task<bool> RemoveExcelCol(int row, int col)
        {
            return Channel.SendData<bool>("removeExcelCol", row, col);
        }

        public Task<bool> RemoveExcelRow(int row, int col)
        {
            return Channel.SendData<bool>("removeExcelRow", row, col);
        }

        public Task<bool> ReplaceBackground(string bgFilePath, int replaceRed = -1, int replaceGreen = -1, int replaceBlue = -1, int simValue = 0)
        {
            return Channel.SendData<bool>("replaceBackground", bgFilePath, replaceRed, replaceGreen, replaceBlue, simValue);
        }

        public Task<bool> RollMouse(int hwnd, int x, int y, int rollCount, bool opMode)
        {
            return Channel.SendData<bool>("rollMouse", hwnd, x, y, rollCount, opMode);
        }

        public Task<bool> SaveExcel(string sheetObject, string excelPath)
        {
            return Channel.SendData<bool>("saveExcel", sheetObject, excelPath);
        }

        public Task<bool> SaveScreenshot(int hwnd, string phoneSavePath, int leftTopX, int leftTopY, int rightBottomX, int rightBottomY, int AlgorithmType, int threshold, int maxValue, bool isbackground)
        {
            return Channel.SendData<bool>("saveScreenshot", hwnd, phoneSavePath, leftTopX, leftTopY, rightBottomX, rightBottomY, AlgorithmType, threshold, maxValue, isbackground);
        }

        public Task<bool> SendKeys(string text)
        {
            return Channel.SendData<bool>("sendKeys", text);
        }

        public Task<bool> SendKeysByHwnd(int hwnd, string text)
        {
            return Channel.SendData<bool>("sendKeysByHwnd", hwnd, text);
        }

        public Task<bool> SendVk(int vk, int inputType)
        {
            return Channel.SendData<bool>("sendVk", vk, inputType);
        }

        public Task<bool> SendVkByHwnd(int hwnd, int vk, int inputType)
        {
            return Channel.SendData<bool>("sendVkByHwnd", hwnd, vk, inputType);
        }

        public Task<bool> SetClipboardText(string text)
        {
            return Channel.SendData<bool>("setClipboardText", text);
        }

        public Task<bool> SetElementFocus(int hwnd, string xpath)
        {
            return Channel.SendData<bool>("setElementFocus", hwnd, xpath);
        }

        public Task<bool> SetElementScroll(int hwnd, string xpath, int horizontalPercent = -1, int verticalPercent = -1)
        {
            return Channel.SendData<bool>("setElementScroll", hwnd, xpath, horizontalPercent, verticalPercent);
        }

        public Task<bool> SetElementValue(int hwnd, string xpath, string value)
        {
            return Channel.SendData<bool>("setElementValue", hwnd, xpath, value);
        }

        public Task<bool> SetWindowPos(int hwnd, int x, int y, int witdh, int hegh)
        {
            return Channel.SendData<bool>("setWindowPos", hwnd, x, y, witdh, hegh);
        }

        public Task<bool> SetWindowState(int hwnd, string xpath, int state)
        {
            return Channel.SendData<bool>("setWindowState", hwnd, xpath, state);
        }

        public Task<bool> SetWindowTop(int hwnd, bool isTop)
        {
            return Channel.SendData<bool>("setWindowTop", hwnd, isTop);
        }

        public Task<bool> ShowSpeechText(int originY = 0, string fontType = "Arial", int fontSize = 30, int fontRed = 128, int fontGreen = 255, int fontBlue = 0, bool italic = false, bool underline = false)
        {
            return Channel.SendData<bool>("showSpeechText", originY, fontType, fontSize, fontRed, fontGreen, fontBlue, italic, underline);
        }

        public Task<bool> ShowWindow(int hwnd, bool showWindows)
        {
            return Channel.SendData<bool>("showWindow", hwnd, showWindows);
        }

        public Task<bool> StartProcess(string commandLine, bool showWindow = true, bool isWait = false)
        {
            return Channel.SendData<bool>("startProcess", commandLine, showWindow, isWait);
        }

        public Task<bool> TextToAudioFile(string ssmlPathOrText, string language, string voiceName, string audioPath)
        {
            return Channel.SendData<bool>("textToAudioFile", ssmlPathOrText, language, voiceName, audioPath);
        }

        public Task<bool> TextToBullhorn(string ssmlPathOrText, string language, string voiceName)
        {
            return Channel.SendData<bool>("textToBullhorn", ssmlPathOrText, language, voiceName);
        }

        public Task<string> UploadTrainFile(string filePath)
        {
            return Channel.SendData<string>("uploadTrainFile", filePath);
        }

        public Task<bool> WriteExcelNum(string sheetObject, int row, int col, int value)
        {
            return Channel.SendData<bool>("writeExcelNum", sheetObject, row, col, value);
        }

        public Task<bool> WriteExcelStr(string sheetObject, int row, int col, string strValue)
        {
            return Channel.SendData<bool>("writeExcelStr", sheetObject, row, col, strValue);
        }
    }
}
