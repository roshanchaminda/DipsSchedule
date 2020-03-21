using System;
using System.Globalization;
using DipsSchedule.Enums;
using DipsSchedule.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DipsSchedule.Converters
{
    public class ScheduleNameConverter : IMarkupExtension, IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ScheduleUserStatus userStatus = (ScheduleUserStatus)value;

            return userStatus.ToDescriptionString();
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
