using System;
using System.Collections.Generic;
using DipsSchedule.Enums;
using DipsSchedule.Models;
using DipsSchedule.ViewModels.Base;
using Xamarin.Forms;

namespace DipsSchedule.ViewModels
{
    public class ScheduleItemViewModel : ViewModelBase
    {
        public ScheduleItemViewModel()
        {

        }

        public UserBasicInfoViewModel UserInfo { get; set; }

        public int ScheduleId { get; set; }

        public DateTime ScheduleDate { get; set; }

        public ScheduleCategory Category { get; set; }

        public string ScheduleTime { get; set; }

        public string RoomNumber { get; set; }

        public string Diagnosis { get; set; }

        public string ReferenceDetail { get; set; }

        public string ContactType { get; set; }

        public string DiagnosisGroup { get; set; }

        public string HealthIssue { get; set; }

        public string TentativeDiagnosis { get; set; }

        public string ReferralReason { get; set; }

        public string LevelOfCare { get; set; }

        public ScheduleUserStatus UserStatus { get; set; }

        public List<UserAppointmentsViewModel> UserAppointments { get; set; }
    }
}
