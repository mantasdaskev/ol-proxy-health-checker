using Microsoft.Practices.Unity;
using Ol.ProxyHealthChecker.Lib;
using Ol.ProxyHealthChecker.ViewModels;
using Ol.ProxyHealthChecker.Views;
using System.Windows.Controls;

namespace Ol.ProxyHealthChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow<MainViewModel>
    {
        public MainWindow(MainViewModel vm) : base(vm)
        {
            InitializeComponent();
        }

        private void HistoryClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var historyVm = App.Container.Resolve<HistoryViewModel>();
            var historyWnd = new HistoryWindow(historyVm, 
                (sender as Button).CommandParameter as string);
            historyWnd.ShowDialog();
        }
    }
}
