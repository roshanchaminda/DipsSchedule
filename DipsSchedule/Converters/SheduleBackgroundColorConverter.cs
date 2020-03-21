using System;
using System.Globalization;
using DipsSchedule.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DipsSchedule.Converters
{
    public class SheduleBackgroundColorConverter : IMarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ScheduleUserStatus userStatus = (ScheduleUserStatus)value;

            if (userStatus == ScheduleUserStatus.Urgent)
            {
                return Color.FromHex("#f56e70");
            }
            else
            {
                return Color.White;
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
