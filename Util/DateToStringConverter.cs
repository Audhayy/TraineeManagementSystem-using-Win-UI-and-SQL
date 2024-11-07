using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace Win_UI_Sample.Utils
{
    public class DateToStringConverter : IValueConverter
    {
        // Convert DateTime to string
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture); // Change format as needed
            }
            return string.Empty;
        }

        // Convert string back to DateTime (optional implementation)
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string dateString && DateTime.TryParse(dateString, out var dateTime))
            {
                return dateTime;
            }
            return null; // Or some default value
        }
    }
}
