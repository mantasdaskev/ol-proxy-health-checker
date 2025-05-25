using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ol.ProxyHealthChecker.Lib
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Predicate<object> _canExecute;
        private bool _isExecuting;

        public event EventHandler CanExecuteChanged;

        public AsyncRelayCommand(Func<Task> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute == null || _canExecute(parameter));
        }

        public async void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            try
            {
                _isExecuting = true;
                RaiseCanExecuteChanged();
                await _execute();
            }
            catch (Exception ex)
            {
                //TODO:
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
