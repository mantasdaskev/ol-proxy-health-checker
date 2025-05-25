using Ol.ProxyHealthChecker.Core.Models;
using System.IO;
using System.Text.Json;

//TODO: get by relative path or something proxies list.

namespace Ol.ProxyHealthChecker.Utils
{
    public class SettingsProvider
    {
        private static SettingsProvider _instance;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private bool _isInitialized = false;

        private SettingsProvider()
        {
        }

        public static SettingsProvider Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new SettingsProvider();
                return _instance;
            }
        }

        public Settings Settings { get; private set; }

        public void Init()
        {
            if (_isInitialized)
            {
                return;
            }

            if (!File.Exists(Settings.SettingsFileName))
            {
                //TODO: throw
                return;
            }

            var file = File.ReadAllText(Settings.SettingsFileName);
            Settings = JsonSerializer.Deserialize<Settings>(file, _options);

            _isInitialized = true;
        }
    }
}
