using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfMachineVision.Support.Local.Converters
{
    public class MultiStringConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Tuple<string, string>(values[0]?.ToString()!, values[1]?.ToString()!);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
