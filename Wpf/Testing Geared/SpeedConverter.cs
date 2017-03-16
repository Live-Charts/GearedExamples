using System;
using System.Globalization;
using System.Windows.Data;

namespace Geared.Wpf.Testing_Geared
{
    public class SpeedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var speed = (string) value;

            switch (speed)
            {
                case "Slow":
                    return TimeSpan.FromMilliseconds(800);
                case "Medium":
                    return TimeSpan.FromMilliseconds(500);
                default:
                    return TimeSpan.FromMilliseconds(180);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}