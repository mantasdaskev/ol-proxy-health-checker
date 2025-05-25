using System.Windows;

namespace Ol.ProxyHealthChecker.Lib
{
    public class BaseWindow<TViewModel> : Window
        where TViewModel : class
    {
        public BaseWindow(TViewModel vm)
        {
            Context = vm;
            DataContext = vm;
        }

        protected TViewModel Context { get; }
    }
}
