using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MarkEdPlace
{
    class WidthCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo) => (double)value - 150;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo) => value;
    }
}
