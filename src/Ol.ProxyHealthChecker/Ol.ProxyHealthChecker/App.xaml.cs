using Microsoft.Practices.Unity;
using Ol.ProxyHealthChecker.Business.Services;
using Ol.ProxyHealthChecker.Core.Interfaces;
using Ol.ProxyHealthChecker.Data;
using Ol.ProxyHealthChecker.Data.Repositories;
using Ol.ProxyHealthChecker.Utils;
using Ol.ProxyHealthChecker.ViewModels;
using System.Windows;

namespace Ol.ProxyHealthChecker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer Container { get; } = new UnityContainer();

        protected override void OnStartup(StartupEventArgs e)
        {
            Container.RegisterInstance(SettingsProvider.Instance);
            Container.RegisterInstance(FakeDataContext.Instance);

            Container.RegisterType<IProxyRepository, ProxyRepository>();
            Container.RegisterType<IProxyCheckService, ProxyCheckService>();

            Container.RegisterType<MainViewModel>();
            Container.RegisterType<HistoryViewModel>();

            SettingsProvider.Instance.Init();
            FakeDataContext.Instance.Init(SettingsProvider.Instance.Settings.ProxyListFilePath);

            MainWindow = new MainWindow(Container.Resolve<MainViewModel>());
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
