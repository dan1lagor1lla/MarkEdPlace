using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MarkEdPlace
{
    class PlaceholderPaddingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            Thickness padding = (Thickness)value;
            padding.Right += 10;
            padding.Left += 10;
            
            return padding;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo cultureInfo) => value;
    }
}
