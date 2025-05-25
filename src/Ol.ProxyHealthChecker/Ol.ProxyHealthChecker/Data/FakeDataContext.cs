using Ol.ProxyHealthChecker.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Ol.ProxyHealthChecker.Data
{
    // I guess it would be better to use EF Core with SQLite or in memory of just in json file
    public class FakeDataContext
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        private static FakeDataContext _instance;
        private bool _initialyzed;

        private FakeDataContext()
        {
        }

        public static FakeDataContext Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new FakeDataContext();
                return _instance;
            }
        }

        public void Init(string filePath)
        {
            if (_initialyzed)
            {
                return;
            }

            ProxyHistory = new List<ProxyHistoryItem>();
            Proxies = GetProxies(filePath);

            _initialyzed = true;
        }

        //Some HashSet or something that does not allow duplicates would be better in this case I guess
        public List<Proxy> Proxies { get; private set; }

        public List<ProxyHistoryItem> ProxyHistory { get; private set; }

        private List<Proxy> GetProxies(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Proxy>();
            }

            var file = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Proxy>>(file, _options);
        }
    }
}
