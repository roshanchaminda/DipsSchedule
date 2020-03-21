using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsSchedule.Enums;
using DipsSchedule.Models;

namespace DipsSchedule.DataStore
{
    public class ScheduleDataStore : IScheduleDataStore
    {
        readonly List<ScheduleDetail> scheduleDetails;

        private List<User> Users = new List<User>()
        {
            new User()
            {
                UserId=1,
                Surname="SCOTT",
                FirstName="Thelma",
                LastName="Louise",
                Gender="Female",
                RegisteredDate=DateTime.Now.AddYears(-5),
                ReferenceNumber="110214-47341",
                ContactNumber="123 23 234",
                Email="scott@m.com"
            },
            new User()
            {
                UserId=2,
                Surname="SCOTT",
                FirstName="Thelma",
                LastName="Louise",
                Gender="Female",
                RegisteredDate=DateTime.Now.AddYears(-5),
                ReferenceNumber="110214-47341",
                ContactNumber="123 23 234",
                Email="scott@m.com"
            },
            new User()
            {
                UserId=3,
                Surname="SCOTT",
                FirstName="Thelma",
                LastName="Louise",
                Gender="Female",
                RegisteredDate=DateTime.Now.AddYears(-5),
                ReferenceNumber="110214-47341",
                ContactNumber="123 23 234",
                Email="scott@m.com"
            }
        };

        private List<UserAppointments> UserAppointments = new List<UserAppointments>()
        {
            new UserAppointments
            {
                AppointmentId=1,
                DepartmentName="Radiology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddHours(3),
                UserId=1
            },
            new UserAppointments
            {
                AppointmentId=2,
                DepartmentName="Otolaryngology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(3),
                UserId=1
            },
            new UserAppointments
            {
                AppointmentId=3,
                DepartmentName="Monthly Follow up",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(5),
                UserId=1
            },
            new UserAppointments
            {
                AppointmentId=4,
                DepartmentName="Radiology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddHours(3),
                UserId=2
            },
            new UserAppointments
            {
                AppointmentId=5,
                DepartmentName="Otolaryngology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(3),
                UserId=2
            },
            new UserAppointments
            {
                AppointmentId=6,
                DepartmentName="Monthly Follow up",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(5),
                UserId=2
            },new UserAppointments
            {
                AppointmentId=7,
                DepartmentName="Radiology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddHours(3),
                UserId=3
            },
            new UserAppointments
            {
                AppointmentId=8,
                DepartmentName="Otolaryngology department",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(3),
                UserId=3
            },
            new UserAppointments
            {
                AppointmentId=9,
                DepartmentName="Monthly Follow up",
                AppointmentDescription="Appointment details",
                AppointmentDate=DateTime.Now.AddDays(1).AddHours(5),
                UserId=3
            }
        };

        public ScheduleDataStore()
        {
            scheduleDetails = new List<ScheduleDetail>
            {
                new ScheduleDetail
                {
                    ScheduleDetailId = 1,
                    UserInfo=Users[0],
                    ScheduleDate=DateTime.Now.AddDays(-3),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="35",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[0].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=2,
                    UserInfo=Users[1],
                    ScheduleDate=DateTime.Now.AddDays(-3),
                    ScheduleCategory=ScheduleCategory.Category2,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.Urgent,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="36",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[1].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=3,
                    UserInfo=Users[2],
                    ScheduleDate=DateTime.Now.AddDays(-2),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.NotArrived,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="37",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[2].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=4,
                    UserInfo=Users[0],
                    ScheduleDate=DateTime.Now.AddDays(-2),
                    ScheduleCategory=ScheduleCategory.Category3,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.Offline,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="38",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[0].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=5,
                    UserInfo=Users[1],
                    ScheduleDate=DateTime.Now.AddDays(-1),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[1].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=6,
                    UserInfo=Users[2],
                    ScheduleDate=DateTime.Now.AddDays(-1),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[2].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=7,
                    UserInfo=Users[0],
                    ScheduleDate=DateTime.Now,
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[0].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=8,
                    UserInfo=Users[1],
                    ScheduleDate=DateTime.Now.AddDays(-1),
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[1].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=9,
                    UserInfo=Users[2],
                    ScheduleDate=DateTime.Now,
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[2].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=10,
                    UserInfo=Users[0],
                    ScheduleDate=DateTime.Now,
                    ScheduleCategory=ScheduleCategory.Category2,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[0].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=11,
                    UserInfo=Users[1],
                    ScheduleDate=DateTime.Now,
                    ScheduleCategory=ScheduleCategory.Category3,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[1].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=12,
                    UserInfo=Users[2],
                    ScheduleDate=DateTime.Now.AddDays(1),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[2].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=8,
                    UserInfo=Users[0],
                    ScheduleDate=DateTime.Now.AddDays(2),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[0].UserId).ToList()
                },
                new ScheduleDetail
                {
                    ScheduleDetailId=8,
                    UserInfo=Users[1],
                    ScheduleDate=DateTime.Now.AddDays(3),
                    ScheduleCategory=ScheduleCategory.Category1,
                    ScheduleTime="15.00 - 15.30",
                    ReferenceDetail="Referred by Dr. David Campbell",
                    UserStatus=ScheduleUserStatus.CheckedIn,
                    Diagnosis="Chest Pain",
                    ContactType="Treatment",
                    DiagnosisGroup="Other cardiothoracic procedures",
                    HealthIssue="Chest pain",
                    TentativeDiagnosis="acute pericarditis",
                    ReferralReason="Complains about chest pain over period of two weeks",
                    LevelOfCare="Outpatient",
                    RoomNumber="39",
                    UserAppointments=UserAppointments.Where(w=>w.UserId==Users[1].UserId).ToList()
                }

            };
        }

        public async Task<ScheduleDetail> GetItemAsync(int scheduleId)
        {
            return await Task.FromResult(scheduleDetails.FirstOrDefault(s => s.ScheduleDetailId == scheduleId));
        }

        public async Task<IEnumerable<ScheduleDetail>> GetItemsAsync()
        {
            return await Task.FromResult(scheduleDetails);
        }
    }
}
