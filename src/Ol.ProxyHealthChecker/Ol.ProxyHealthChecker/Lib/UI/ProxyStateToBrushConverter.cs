using Ol.ProxyHealthChecker.Core.Models.Enum;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Ol.ProxyHealthChecker.Lib.UI
{
    public class ProxyStateToBrushConverter : IValueConverter
    {
        public Brush HealthyBrush { get; set; } = Brushes.Green;
        public Brush UnknownBrush { get; set; } = Brushes.DimGray;
        public Brush UnavailableBrush { get; set; } = Brushes.Orange;
        public Brush DownBrush { get; set; } = Brushes.Red;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (ProxyState)value;
            switch (state)
            {
                case ProxyState.Healthy:
                    return HealthyBrush;
                case ProxyState.Unavailable:
                    return UnavailableBrush;
                case ProxyState.Down:
                    return DownBrush;
                default:
                    return UnknownBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}