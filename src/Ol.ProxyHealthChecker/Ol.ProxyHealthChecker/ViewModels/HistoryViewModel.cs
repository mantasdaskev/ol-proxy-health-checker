using Ol.ProxyHealthChecker.Core.Interfaces;
using Ol.ProxyHealthChecker.Core.Models;
using Ol.ProxyHealthChecker.Lib;
using System.Collections.Generic;

namespace Ol.ProxyHealthChecker.ViewModels
{
    public class HistoryViewModel : Observable
    {
        private readonly IProxyCheckService _proxyService;

        private List<ProxyItem> _proxies = new List<ProxyItem>();
        public HistoryViewModel(IProxyCheckService proxyService)
        {
            _proxyService = proxyService;
        }

        public List<ProxyItem> Proxies
        {
            get => _proxies;
            set => SetProperty(ref _proxies, value);
        }

        public void LoadList(string ip)
        {
            Proxies = _proxyService.GetHistory(ip);
        }
    }
}
