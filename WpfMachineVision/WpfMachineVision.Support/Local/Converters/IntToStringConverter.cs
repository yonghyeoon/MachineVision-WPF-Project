using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfMachineVision.Support.Local.Converters
{
    public class IntToStringConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int IntValue)
        {
                return IntValue.ToString(culture); // 정수 형태로 변환
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
