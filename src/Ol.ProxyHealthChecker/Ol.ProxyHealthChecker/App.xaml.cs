using Microsoft.Practices.Unity;
using Ol.ProxyHealthChecker.Services;
using Ol.ProxyHealthChecker.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

            //TODO: interfaces and layers

            Container.RegisterType<ProxyDataService>();
            Container.RegisterType<ProxyService>();
            Container.RegisterType<MainViewModel>();
            //Container.RegisterType<MainWindow>();

            MainWindow = new MainWindow(Container.Resolve<MainViewModel>());
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
