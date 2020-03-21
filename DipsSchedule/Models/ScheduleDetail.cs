using System;
using System.Collections.Generic;
using DipsSchedule.Enums;

namespace DipsSchedule.Models
{
    public class ScheduleDetail
    {
        public ScheduleDetail()
        {

        }

        public int ScheduleDetailId { get; set; }

        public DateTime ScheduleDate { get; set; }

        public ScheduleCategory ScheduleCategory { get; set; }

        public string ScheduleTime { get; set; }

        public string RoomNumber { get; set; }

        public string ReferenceDetail { get; set; }

        public string Diagnosis { get; set; }

        public string ContactType { get; set; }

        public string DiagnosisGroup { get; set; }

        public string HealthIssue { get; set; }

        public string TentativeDiagnosis { get; set; }

        public string ReferralReason { get; set; }

        public string LevelOfCare { get; set; }

        public ScheduleUserStatus UserStatus { get; set; }

        public User UserInfo { get; set; }

        public List<UserAppointments> UserAppointments { get; set; }

    }
}
