using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AiboteDotNet.WebBot
{
    public class WebBotCore : IWebBotCore
    {
        static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();
        public TcpChannel Channel { get; set; }

        public WebBotCore(TcpChannel tcpChannel)
        {
            Channel = tcpChannel;
        }
        public Task<bool> Back()
        {
            return Channel.SendData<bool>("back");
        }

        public Task<bool> ClearCache()
        {
            return Channel.SendData<bool>("clearCache");
        }

        public Task<bool> ClearElement(string elementXpath)
        {
            return Channel.SendData<bool>("clearElement", elementXpath);
        }

        public Task<bool> ClickAlert(bool accept, string promptText)
        {
            return Channel.SendData<bool>("clickAlert", accept, promptText);
        }

        public Task<bool> ClickElement(string elementXpath)
        {
            return Channel.SendData<bool>("clickElement", elementXpath);
        }

        public Task<bool> ClickMouse(string x, string y, int button)
        {
            return Channel.SendData<bool>("clickMouse", x, y, button);
        }

        public Task<bool> ClickMouseByXpath(string elementXpath, int button)
        {
            return Channel.SendData<bool>("clickMouseByXpath", elementXpath, button);
        }

        public Task<bool> CloseBrowser()
        {
            return Channel.SendData<bool>("closeBrowser");
        }

        public Task<bool> CloseDriver()
        {
            return Channel.SendData<bool>("closeDriver");
        }

        public Task<bool> ClosePage()
        {
            return Channel.SendData<bool>("closePage");
        }

        public Task<bool> DeleteAllCookies()
        {
            return Channel.SendData<bool>("deleteAllCookies");
        }

        public Task<bool> DeleteCookies(string name, string domain, string path, bool isSameParty, bool isSecure)
        {
            return Channel.SendData<bool>("deleteCookies", name, domain, path, isSameParty, isSecure);
        }

        public Task<string> ExecuteScript(string script)
        {
            return Channel.SendData<string>("executeScript", script);
        }

        public Task<bool> Forward()
        {
            return Channel.SendData<bool>("forward");
        }

        public Task<string> GetAlertText()
        {
            return Channel.SendData<string>("getAlertText");
        }

        public Task<string> GetAllCookies()
        {
            return Channel.SendData<string>("getAllCookies");
        }

        public Task<string> GetAllPageId()
        {
            return Channel.SendData<string>("getAllPageId");
        }

        public Task<string> GetCookies(string url)
        {
            return Channel.SendData<string>("getCookies", url);
        }

        public Task<string> GetCurPageId()
        {
            return Channel.SendData<string>("getCurPageId");
        }

        public Task<string> GetCurrentUrl()
        {
            return Channel.SendData<string>("getCurrentUrl");
        }

        public Task<string> GetElementAttribute(string elementXpath, string attributeName)
        {
            return Channel.SendData<string>("getElementAttribute", elementXpath, attributeName);
        }

        public Task<string> GetElementInnerHTML(string elementXpath)
        {
            return Channel.SendData<string>("getElementInnerHTML", elementXpath);
        }

        public Task<string> GetElementOuterHTML(string elementXpath)
        {
            return Channel.SendData<string>("getElementOuterHTML", elementXpath);
        }

        public Task<string> GetElementRect(string elementXpath)
        {
            return Channel.SendData<string>("getElementRect", elementXpath);
        }

        public Task<string> GetElementText(string elementXpath)
        {
            return Channel.SendData<string>("getElementText", elementXpath);
        }

        public Task<string> GetExtendParam()
        {
            return Channel.SendData<string>("getExtendParam");
        }

        public Task<string> GetTitle()
        {
            return Channel.SendData<string>("getTitle");
        }

        public Task<string> GetWindowPos()
        {
            return Channel.SendData<string>("getWindowPos");
        }

        public Task<bool> Goto(string url)
        {
            return Channel.SendData<bool>("goto", url);
        }

        public Task<bool> IsDisplayed(string elementXpath)
        {
            return Channel.SendData<bool>("isDisplayed", elementXpath);
        }

        public Task<bool> IsEnabled(string elementXpath)
        {
            return Channel.SendData<bool>("isEnabled", elementXpath);
        }

        public Task<bool> IsSelected(string elementXpath)
        {
            return Channel.SendData<bool>("isSelected", elementXpath);
        }

        public Task<bool> MobileEmulation(int width, int height, string userAgent, string platform, string platformVersion, string language, string timeZone, float latitude, float longitude, float accuracy)
        {
            return Channel.SendData<bool>("mobileEmulation", width, height, userAgent, platform, platformVersion, language, timeZone, latitude, longitude, accuracy);
        }

        public Task<bool> MoveMouse(string x, string y)
        {
            return Channel.SendData<bool>("moveMouse", x, y);
        }

        public Task<bool> MoveMouseByXpath(string elementXpath)
        {
            return Channel.SendData<bool>("moveMouseByXpath", elementXpath);
        }

        public Task<bool> NewPage(string url)
        {
            return Channel.SendData<bool>("newPage", url);
        }

        public Task<bool> Refresh()
        {
            return Channel.SendData<bool>("refresh");
        }

        public Task<bool> SendKeys(string elementXpath, string text)
        {
            return Channel.SendData<bool>("sendKeys", elementXpath, text);
        }

        public Task<bool> SendVk(string key)
        {
            return Channel.SendData<bool>("sendVk", key);
        }

        public Task<bool> SetCookie(string name, string value, string domain, string path, bool secure, bool httpOnly, string expiry, int maxAge, string sameSite, bool isSameParty, bool isSession)
        {
            return Channel.SendData<bool>("setCookie", name, value, domain, path, secure, httpOnly, expiry, maxAge, sameSite, isSameParty, isSession);
        }

        public Task<bool> SetElementAttribute(string elementXpath, string attributeName, string attributeValue)
        {
            return Channel.SendData<bool>("setElementAttribute", elementXpath, attributeName, attributeValue);
        }

        public Task<bool> SetElementFocus(string elementXpath)
        {
            return Channel.SendData<bool>("setElementFocus", elementXpath);
        }

        public Task<bool> SetElementValue(string elementXpath, string value)
        {
            return Channel.SendData<bool>("setElementValue", elementXpath, value);
        }

        public Task<bool> SetWindowPos(string windowState, int left, int top, int width, int height)
        {
            return Channel.SendData<bool>("setWindowPos", windowState, left, top, width, height);
        }

        public Task<bool> SwitchFrame(string frameXpath)
        {
            return Channel.SendData<bool>("switchFrame", frameXpath);
        }

        public Task<bool> SwitchMainFrame()
        {
            return Channel.SendData<bool>("switchMainFrame");
        }

        public Task<bool> SwitchPage(string pageId)
        {
            return Channel.SendData<bool>("switchPage", pageId);
        }

        public Task<string> TakeScreenshot()
        {
            return Channel.SendData<string>("takeScreenshot");
        }

        public Task<string> TakeScreenshot(string elementXpath)
        {
            return Channel.SendData<string>("takeScreenshot", elementXpath);
        }

        public Task<bool> TouchEnd(string x, string y)
        {
            return Channel.SendData<bool>("touchEnd", x, y);
        }

        public Task<bool> TouchMove(string x, string y)
        {
            return Channel.SendData<bool>("touchMove", x, y);
        }

        public Task<bool> TouchStart(string x, string y)
        {
            return Channel.SendData<bool>("touchStart", x, y);
        }

        public Task<bool> UploadFile(string elementXpath, string filePath)
        {
            return Channel.SendData<bool>("uploadFile", elementXpath, filePath);
        }

        public Task<bool> WheelMouse(string deltaX, string deltaY, string deltaZ, string elementXpath)
        {
            return Channel.SendData<bool>("wheelMouse", deltaX, deltaY, deltaZ, elementXpath);
        }

        public Task<bool> WheelMouseByXpath(string deltaX, string deltaY, string elementXpath)
        {
            return Channel.SendData<bool>("wheelMouseByXpath", deltaX, deltaY, elementXpath);
        }
    }
}
