using System;
using System.Globalization;
using System.Windows.Data;

namespace BindingTypesDemo.Converters
{
    public class NameToInitialsConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string name && !string.IsNullOrEmpty(name))
            {
                // 取第一个字符作为缩写
                return name.Substring(0, 1);
            }
            
            return "?";
        }
        
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 