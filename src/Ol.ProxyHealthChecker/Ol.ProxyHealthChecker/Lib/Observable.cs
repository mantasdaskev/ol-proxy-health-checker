using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ol.ProxyHealthChecker.Lib
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Notifies listeners of property changes.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Sets the backing field and raises PropertyChanged if the value changes.
        protected bool SetProperty<T>(ref T backingField, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingField, newValue))
                return false;

            backingField = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
