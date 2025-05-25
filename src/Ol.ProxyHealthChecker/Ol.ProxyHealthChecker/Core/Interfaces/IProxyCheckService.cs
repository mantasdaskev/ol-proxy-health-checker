using Ol.ProxyHealthChecker.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ol.ProxyHealthChecker.Core.Interfaces
{
    public interface IProxyCheckService
    {
        Task<List<ProxyItem>> CheckProxiesAsync();

        Task<ProxyItem> CheckSingleProxyAsync(ProxyItem proxyItem);

        List<ProxyItem> GetHistory(string ip);
    }
}
