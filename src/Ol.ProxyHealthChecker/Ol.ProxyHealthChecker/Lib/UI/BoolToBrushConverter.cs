using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Ol.ProxyHealthChecker.Lib.UI
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush HealthyBrush { get; set; } = Brushes.Green;
        public Brush UnhealthyBrush { get; set; } = Brushes.Red;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool b && b) ? HealthyBrush : UnhealthyBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

    }
}