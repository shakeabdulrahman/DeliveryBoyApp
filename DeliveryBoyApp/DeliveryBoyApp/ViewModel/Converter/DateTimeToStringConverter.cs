using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DeliveryBoyApp.ViewModel.Converter
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeago = string.Empty;
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset timenow = DateTimeOffset.Now;

            var difference = timenow - dateTime;

            if (difference.TotalDays > 1)
                return $"{dateTime:d}";
            else
            {
                if (difference.TotalSeconds < 60)
                    return $"{difference.TotalSeconds:0} seconds ago";
                if (difference.TotalMinutes < 60)
                    return $"{difference.TotalMinutes:0} minutes ago";
                if (difference.TotalHours < 24)
                    return $"{difference.TotalHours:0} hours ago";

                return "Yesterday";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
