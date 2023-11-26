

using Newtonsoft.Json;

namespace AiboteNotNet.App.Common
{
    public class Settings
    {
        public static Settings Ins;

        public string androidBotServerIp;
        public int androidBotServerPort;

        public string windowsBotServerIp;
        public int windowsBotServerPort;

        public string webBotServerIp;
        public int webBotServerPort;

        public static bool AppRunning { get; internal set; }
        public static DateTime LauchTime { get; internal set; }

        public static void Load(string path)
        {
            var configJson = File.ReadAllText(path);
            Ins = JsonConvert.DeserializeObject<Settings>(configJson);
        }
    }
}
