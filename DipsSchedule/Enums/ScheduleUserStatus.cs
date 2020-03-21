using System;
using System.ComponentModel;

namespace DipsSchedule.Enums
{
    public enum ScheduleUserStatus
    {
        [Description("Urgent")]
        Urgent,
        [Description("Urgent")]
        Arrived,
        [Description("Not Arrived")]
        NotArrived,
        [Description("Checked In")]
        CheckedIn,
        [Description("Offline")]
        Offline
    }
}
