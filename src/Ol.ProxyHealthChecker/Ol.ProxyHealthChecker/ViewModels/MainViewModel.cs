using Ol.ProxyHealthChecker.Lib;
using Ol.ProxyHealthChecker.Models;
using Ol.ProxyHealthChecker.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ol.ProxyHealthChecker.ViewModels
{
    public class MainViewModel : Observable
    {
        private readonly ProxyService _proxyService;
        private List<ProxyItem> _proxies = new List<ProxyItem>();

        public MainViewModel(ProxyService proxyService)
        {
            _proxyService = proxyService;

            CheckNowCommand = new AsyncRelayCommand(CheckNow);
        }

        public ICommand CheckNowCommand { get; }

        public List<ProxyItem> Proxies
        {
            get => _proxies;
            set => SetProperty(ref _proxies, value);
        }

        private async Task CheckNow()
        {
            Proxies = await _proxyService.CheckProxiesAsync();
        }
    }
}
