using Ol.ProxyHealthChecker.Core.Models.Enum;
using System;

namespace Ol.ProxyHealthChecker.Core.Models
{
    public class ProxyHistoryItem
    {
        public string Ip { get; set; }
        public ProxyState State { get; set; }
        public string StatusMessage { get; set; }
        public DateTime LastChecked { get; set; }
    }
}
