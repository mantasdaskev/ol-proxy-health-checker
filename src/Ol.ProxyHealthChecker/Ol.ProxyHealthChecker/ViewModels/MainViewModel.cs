using Ol.ProxyHealthChecker.Core.Interfaces;
using Ol.ProxyHealthChecker.Core.Models;
using Ol.ProxyHealthChecker.Lib;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ol.ProxyHealthChecker.ViewModels
{
    public class MainViewModel : Observable
    {
        private readonly IProxyCheckService _proxyService;

        private ObservableCollection<ProxyItem> _proxies = new ObservableCollection<ProxyItem>();
        private bool _isCheckRunning = false;

        public MainViewModel(IProxyCheckService proxyService)
        {
            _proxyService = proxyService;

            CheckNowCommand = new AsyncRelayCommand(CheckNow);
            CheckSingleCommand = new AsyncRelayCommand<ProxyItem>(CheckSingle);
        }

        public ICommand CheckNowCommand { get; }

        public ICommand CheckSingleCommand { get; }

        public ObservableCollection<ProxyItem> Proxies
        {
            get => _proxies;
            set => SetProperty(ref _proxies, value);
        }

        public bool IsCheckRunning
        {
            get => _isCheckRunning;
            set => SetProperty(ref _isCheckRunning, value);
        }

        private async Task CheckNow()
        {
            IsCheckRunning = true;

            var proxies = await _proxyService.CheckProxiesAsync();
            Proxies = new ObservableCollection<ProxyItem>(proxies);

            IsCheckRunning = false;
        }

        private async Task CheckSingle(ProxyItem proxy)
        {
            IsCheckRunning = true;

            var updated = await _proxyService.CheckSingleProxyAsync(proxy);
            var idx = Proxies.ToList().FindIndex(x => x.Ip == updated.Ip);
            Proxies[idx] = updated;
            OnPropertyChanged(nameof(Proxies));

            IsCheckRunning = false;
        }
    }
}
