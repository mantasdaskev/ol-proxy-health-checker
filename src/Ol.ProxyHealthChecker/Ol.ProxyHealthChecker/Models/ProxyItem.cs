using System;

namespace Ol.ProxyHealthChecker.Models
{
    public class ProxyItem
    {
        //TODO: check for mutability
        public string Ip { get; set; }

        public string Location { get; set; }

        public bool IsHealthy { get; set; }
        public DateTime LastChecked { get; set; }
        public string StatusMessage { get; set; }
    }
}
