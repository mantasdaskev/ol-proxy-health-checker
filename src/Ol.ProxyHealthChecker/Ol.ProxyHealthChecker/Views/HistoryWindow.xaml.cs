using Ol.ProxyHealthChecker.Lib;
using Ol.ProxyHealthChecker.ViewModels;
using System;

namespace Ol.ProxyHealthChecker.Views
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : BaseWindow<HistoryViewModel>
    {
        private readonly string _ip;

        public HistoryWindow(HistoryViewModel vm, string ip) : base(vm)
        {
            InitializeComponent();
            _ip = ip;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            Context.LoadList(_ip);
        }
    }
}
