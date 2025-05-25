using Ol.ProxyHealthChecker.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Ol.ProxyHealthChecker.Services
{
    //TODO: repo + service?
    public class ProxyDataService
    {
        //TODO: From config?
        private const string ProxiesFile = "proxies.json";

        private readonly JsonSerializerOptions _settings = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //TODO: async?
        public List<ProxyItem> GetProxyList()
        {
            var file = File.ReadAllText(ProxiesFile);
            return JsonSerializer.Deserialize<List<ProxyItem>>(file, _settings);
        }
    }
}
