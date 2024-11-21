using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfMachineVision.Support.Local.Converters
{
    public class StringToIntConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && double.TryParse(stringValue, NumberStyles.Any, culture, out double result))
            {
                if(result > 255) { result = 255; }
                else if (result < 0) { result = 0; }
                return result; // string을 double로 변환
            }
            return 0; // 유효하지 않은 값일 경우 기본값 0.0
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue.ToString(); // double을 string으로 변환 (소수점 2자리로 고정)
            }
            return string.Empty;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
