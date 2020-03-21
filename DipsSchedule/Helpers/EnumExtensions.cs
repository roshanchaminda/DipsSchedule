using System;
using System.ComponentModel;
using DipsSchedule.Enums;

namespace DipsSchedule.Helpers
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this ScheduleUserStatus val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
