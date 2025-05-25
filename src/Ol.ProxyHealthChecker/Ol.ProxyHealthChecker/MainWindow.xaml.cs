using Microsoft.Practices.Unity;
using Ol.ProxyHealthChecker.Lib;
using Ol.ProxyHealthChecker.Services;
using Ol.ProxyHealthChecker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
