using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Ol.ProxyHealthChecker.Core.Interfaces;
using Ol.ProxyHealthChecker.Utils;
using Ol.ProxyHealthChecker.Core.Models;
using Ol.ProxyHealthChecker.Core.Models.Enum;

namespace Ol.ProxyHealthChecker.Business.Services
{
    internal class ProxyCheckService : IProxyCheckService
    {
        private readonly IProxyRepository _repo;
        private readonly Settings _settings;

        public ProxyCheckService(IProxyRepository repo, SettingsProvider settings)
        {
            _repo = repo;
            _settings = settings.Settings;
        }

        public async Task<List<ProxyItem>> CheckProxiesAsync()
        {
            var proxyList = _repo.GetAll();

            var tasks = new List<Task>();

            foreach (var proxy in proxyList)
            {
                tasks.Add(CheckProxyAsync(proxy));
            }

            await Task.WhenAll(tasks);

            return _repo.UpdateAll(proxyList);
        }

        public async Task<ProxyItem> CheckSingleProxyAsync(ProxyItem proxyItem)
        {
            var proxy = _repo.GetByIp(proxyItem.Ip);
            await CheckProxyAsync(proxy);
            return _repo.Update(proxy);
        }

        private async Task CheckProxyAsync(ProxyItem proxy)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy($"{proxy.Ip}:{_settings.ProxyCheckDefaultPort}"),
                    UseProxy = true
                };

                using (var httpClient = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(_settings.ProxyCheckTimeoutSeconds)
                })
                {
                    var response = await httpClient.GetAsync(_settings.ProxyCheckUrl, cancellationToken: default);

                    proxy.State = response.IsSuccessStatusCode ? ProxyState.Healthy : ProxyState.Unavailable;
                    proxy.StatusMessage = response.IsSuccessStatusCode ? "Healthy" : $"Status: {response.StatusCode}";
                }
            }
            catch (TaskCanceledException)
            {
                proxy.State = ProxyState.Down;
                proxy.StatusMessage = "Timed-out";
            }
            catch (Exception ex)
            {
                proxy.State = ProxyState.Down;
                proxy.StatusMessage = ex.Message.Split('\n')[0];
            }
            finally
            {
                proxy.LastChecked = DateTime.Now;
            }
        }

        public List<ProxyItem> GetHistory(string ip)
        {
            return _repo.GetHistory(ip);
        }
    }
}
