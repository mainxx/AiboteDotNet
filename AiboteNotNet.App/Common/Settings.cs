

using Newtonsoft.Json;

namespace AiboteNotNet.App.Common
{
    public class Settings
    {
        public static Settings Ins;

        public string serverIp;
        public int serverPort;

        public static bool AppRunning { get; internal set; }
        public static DateTime LauchTime { get; internal set; }

        public static void Load(string path)
        {
            var configJson = File.ReadAllText(path);
            Ins = JsonConvert.DeserializeObject<Settings>(configJson);
        }
    }
}
