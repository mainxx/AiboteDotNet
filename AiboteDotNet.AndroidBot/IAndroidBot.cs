using AiboteDotNet.AndroidBot.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot
{
    public interface IAndroidBot :
        IAndroidFileOperation,
        IClickGesture,
        IClipboard,
        IConnect,
        IElement,
        IFileTransfer,
        IHid,
        IImageSize,
        IKey,
        IIntentJump,
        IOcr,
        IPackageActivity,
        IPicturesColors,
        IScreenProjectionInfo,
        IScreenSize,
        IScriptControl,
        IStartApp,
        IText,
        IToast,
        IUrlRequest,
        IVerificationCodeSystem,
        IWeChat
    {
    }
}
