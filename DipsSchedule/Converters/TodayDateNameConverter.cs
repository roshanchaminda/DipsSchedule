using System;
using System.Globalization;
using DipsSchedule.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DipsSchedule.Converters
{
    public class TodayDateNameConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;

            if (dateTime.Date == DateTime.Today)
            {
                return Constants.TodayDateDisplayValue;
            }
            else
            {
                return dateTime.ToString("ddd").ToUpperInvariant().Substring(0, 3);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
