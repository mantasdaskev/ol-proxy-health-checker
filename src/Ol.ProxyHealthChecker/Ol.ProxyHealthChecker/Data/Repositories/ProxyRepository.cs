using Ol.ProxyHealthChecker.Core.Interfaces;
using Ol.ProxyHealthChecker.Core.Models;
using Ol.ProxyHealthChecker.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ol.ProxyHealthChecker.Data.Repositories
{
    internal class ProxyRepository : IProxyRepository
    {
        private readonly FakeDataContext _context;

        public ProxyRepository(FakeDataContext context)
        {
            _context = context;
        }

        public List<ProxyItem> GetAll()
        {
            //With EF Core you could just include to form query but yeah...
            return _context.Proxies.Select(x => new ProxyItem()
            {
                Ip = x.Ip,
                Location = x.Location,
                State = _context.ProxyHistory.LastOrDefault(y => y.Ip == x.Ip)?.State ?? ProxyState.Unknown,
                StatusMessage = _context.ProxyHistory.LastOrDefault(y => y.Ip == x.Ip)?.StatusMessage ?? string.Empty,
                LastChecked = _context.ProxyHistory.LastOrDefault(y => y.Ip == x.Ip)?.LastChecked ?? DateTime.MinValue
            }).ToList() ?? new List<ProxyItem>();
        }

        public ProxyItem GetByIp(string ip)
        {
            var proxy = _context.Proxies
                .FirstOrDefault(x => x.Ip == ip);
            // Mapping would be good..
            return new ProxyItem
            {
                Ip = proxy.Ip,
                Location = proxy.Location,
                State = _context.ProxyHistory.LastOrDefault(y => y.Ip == proxy.Ip)?.State ?? ProxyState.Unknown,
                StatusMessage = _context.ProxyHistory.LastOrDefault(y => y.Ip == proxy.Ip)?.StatusMessage ?? string.Empty,
                LastChecked = _context.ProxyHistory.LastOrDefault(y => y.Ip == proxy.Ip)?.LastChecked ?? DateTime.MinValue
            };
        }

        public ProxyItem Update(ProxyItem proxy)
        {
            _context.ProxyHistory.Add(new ProxyHistoryItem
            {
                Ip = proxy.Ip,
                State = proxy.State,
                StatusMessage = proxy.StatusMessage,
                LastChecked = proxy.LastChecked,
            });
            return proxy;
        }

        public List<ProxyItem> UpdateAll(List<ProxyItem> proxies)
        {
            foreach (var proxy in proxies)
            {
                _context.ProxyHistory.Add(new ProxyHistoryItem
                {
                    Ip = proxy.Ip,
                    State = proxy.State,
                    StatusMessage = proxy.StatusMessage,
                    LastChecked = proxy.LastChecked,
                });
            }
            return proxies;
        }

        public List<ProxyItem> GetHistory(string ip)
        {
            var proxy = _context.Proxies
                .FirstOrDefault(x => x.Ip == ip);
            return _context.ProxyHistory
                .Where(x => x.Ip == ip)
                .Select(x => new ProxyItem()
            {
                Ip = x.Ip,
                Location = proxy.Location,
                State = x.State,
                StatusMessage = x.StatusMessage,
                LastChecked = x.LastChecked
            }).ToList();
        }
    }
}
