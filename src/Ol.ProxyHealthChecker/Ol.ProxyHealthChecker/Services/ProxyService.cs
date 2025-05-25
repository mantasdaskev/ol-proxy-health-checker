using Ol.ProxyHealthChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ol.ProxyHealthChecker.Services
{
    //TODO: to internal when iface added
    public class ProxyService
    {
        private const string TestUrl = "http://ip.oxylabs.io";
        private const int TimeoutSeconds = 5;

        private readonly List<ProxyItem> _proxyList;

        public ProxyService(ProxyDataService dataService)
        {
            _proxyList = dataService.GetProxyList(); //TODO: if async than add initialyzer or smth
        }

        public async Task<List<ProxyItem>> CheckProxiesAsync(CancellationToken cancellationToken = default)
        {
            var tasks = new List<Task>();

            foreach (var proxy in _proxyList)
            {
                tasks.Add(CheckProxyAsync(proxy, cancellationToken));
            }

            await Task.WhenAll(tasks);

            //TODO: a bit shit. rewrite:

            return _proxyList;
        }

        private async Task CheckProxyAsync(ProxyItem proxy, CancellationToken cancellationToken)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy($"{proxy.Ip}:80"), // or change port if needed
                    UseProxy = true
                };

                using (var httpClient = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(TimeoutSeconds)
                })
                {
                    var response = await httpClient.GetAsync(TestUrl, cancellationToken);

                    proxy.IsHealthy = response.IsSuccessStatusCode;
                    proxy.StatusMessage = response.IsSuccessStatusCode ? "Healthy" : $"Status: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                proxy.IsHealthy = false;
                proxy.StatusMessage = $"Down ({ex.Message.Split('\n')[0]})";
            }
            finally
            {
                proxy.LastChecked = DateTime.Now;
            }
        }
    }
}
