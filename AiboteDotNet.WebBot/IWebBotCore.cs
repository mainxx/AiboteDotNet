using AiboteDotNet.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AiboteDotNet.WebBot
{
    public interface IWebBotCore
    {
        public TcpChannel Channel { get; set; }
        Task<bool> Goto(string url);

        Task<bool> NewPage(string url);

        Task<bool> Back();

        Task<bool> Forward();

        Task<bool> Refresh();

        Task<string> GetCurPageId();

        Task<string> GetAllPageId();

        Task<bool> SwitchPage(string pageId);

        Task<bool> ClosePage();

        Task<string> GetCurrentUrl();

        Task<string> GetTitle();

        Task<bool> SwitchFrame(string frameXpath);

        Task<bool> SwitchMainFrame();

        Task<bool> ClickElement(string elementXpath);

        Task<bool> SetElementValue(string elementXpath, string value);

        Task<string> GetElementText(string elementXpath);

        Task<string> GetElementOuterHTML(string elementXpath);

        Task<string> GetElementInnerHTML(string elementXpath);

        Task<bool> SetElementAttribute(string elementXpath, string attributeName, string attributeValue);

        Task<string> GetElementAttribute(string elementXpath, string attributeName);

        Task<string> GetElementRect(string elementXpath);

        Task<bool> IsSelected(string elementXpath);

        Task<bool> IsDisplayed(string elementXpath);

        Task<bool> IsEnabled(string elementXpath);

        Task<bool> ClearElement(string elementXpath);

        Task<bool> SetElementFocus(string elementXpath);

        Task<bool> UploadFile(string elementXpath, string filePath);

        Task<bool> SendKeys(string elementXpath, string text);

        Task<bool> SendVk(string key);

        Task<bool> ClickMouse(string x, string y, int button);

        Task<bool> MoveMouse(string x, string y);

        Task<bool> WheelMouse(string deltaX, string deltaY, string deltaZ, string elementXpath);

        Task<bool> ClickMouseByXpath(string elementXpath, int button);

        Task<bool> MoveMouseByXpath(string elementXpath);

        Task<bool> WheelMouseByXpath(string deltaX, string deltaY, string elementXpath);

        Task<bool> TouchStart(string x, string y);

        Task<bool> TouchMove(string x, string y);

        Task<bool> TouchEnd(string x, string y);

        Task<string> TakeScreenshot();

        Task<string> TakeScreenshot(string elementXpath);

        Task<bool> ClickAlert(bool accept, string promptText);

        Task<string> GetAlertText();

        Task<string> GetCookies(string url);

        Task<string> GetAllCookies();

        Task<bool> SetCookie(string name, string value, string domain, string path, bool secure, bool httpOnly, string expiry, int maxAge, string sameSite, bool isSameParty, bool isSession);

        Task<bool> DeleteCookies(string name, string domain, string path, bool isSameParty, bool isSecure);

        Task<bool> DeleteAllCookies();

        Task<bool> ClearCache();

        Task<string> ExecuteScript(string script);

        Task<string> GetWindowPos();

        Task<bool> SetWindowPos(string windowState, int left, int top, int width, int height);

        Task<string> GetExtendParam();

        Task<bool> MobileEmulation(int width, int height, string userAgent, string platform, string platformVersion, string language, string timeZone, float latitude, float longitude, float accuracy);

        Task<bool> CloseBrowser();

        Task<bool> CloseDriver();
    }
}
