using Ol.ProxyHealthChecker.Core.Models;
using System.Collections.Generic;

namespace Ol.ProxyHealthChecker.Core.Interfaces
{
    public interface IProxyRepository
    {
        List<ProxyItem> GetAll();

        ProxyItem GetByIp(string ip);

        ProxyItem Update(ProxyItem proxy);

        List<ProxyItem> UpdateAll(List<ProxyItem> proxies);
        
        List<ProxyItem> GetHistory(string ip);
    }
}
