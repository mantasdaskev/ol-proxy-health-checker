namespace Ol.ProxyHealthChecker.Core.Models
{
    //TODO: add file and the rest.
    public class Settings
    {
        public const string SettingsFileName = "appSettings.json";

        public string ProxyListFilePath { get; set; }

        public int ProxyCheckTimeoutSeconds { get; set; }

        public string ProxyCheckUrl { get; set; }

        public int ProxyCheckDefaultPort { get; set; }
    }
}
