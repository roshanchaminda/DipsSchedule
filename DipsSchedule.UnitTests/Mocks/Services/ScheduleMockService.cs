using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsSchedule.Enums;
using DipsSchedule.Models;
using DipsSchedule.Services;
using DipsSchedule.ViewModels;

namespace DipsSchedule.UnitTests.Mocks.Services
{
    public class ScheduleMockService : IScheduleService
    {
        private const int loopStartValue = -3;

        private const int loopEndValue = 4;

        private static List<User> Users = new List<User>()
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

        private static List<UserAppointments> UserAppointments = new List<UserAppointments>()
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

        private static List<ScheduleDetail> ScheduleDetails = new List<ScheduleDetail>()
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
        };

        public ScheduleMockService()
        {

        }

        public async Task<List<ScheduleItemViewModel>> GetAllSchedules()
        {
            await Task.Delay(10);

            List<ScheduleItemViewModel> scheduleItemList = new List<ScheduleItemViewModel>();

            foreach (ScheduleDetail detail in ScheduleDetails)
            {
                ScheduleItemViewModel scheduleItemViewModel = AddScheduleItem(detail);

                scheduleItemList.Add(scheduleItemViewModel);
            }

            return scheduleItemList;
        }

        public async Task<List<DateCellViewModel>> GetCurrentWeekData()
        {
            List<DateCellViewModel> weekDaysViewList = new List<DateCellViewModel>();

            for (int i = loopStartValue; i < loopEndValue; i++)
            {
                DateCellViewModel dateCell = new DateCellViewModel();
                dateCell.DateValue = DateTime.Now.AddDays(i);
                dateCell.IsSelectedCell = i == 0 ? true : false;
                dateCell.DateCellIndex = i + loopStartValue * -1;

                weekDaysViewList.Add(dateCell);
            }

            return await Task.FromResult(weekDaysViewList);
        }

        public async Task<ScheduleItemViewModel> GetScheduleItem(int scheduleId)
        {
            await Task.Delay(10);

            ScheduleDetail detail = ScheduleDetails.Where(w => w.ScheduleDetailId == scheduleId).FirstOrDefault();

            ScheduleItemViewModel scheduleItemViewModel = AddScheduleItem(detail);

            return scheduleItemViewModel;
        }

        private static ScheduleItemViewModel AddScheduleItem(ScheduleDetail detail)
        {
            ScheduleItemViewModel scheduleItemViewModel = new ScheduleItemViewModel();
            scheduleItemViewModel.ScheduleId = detail.ScheduleDetailId;
            scheduleItemViewModel.ScheduleDate = detail.ScheduleDate;
            scheduleItemViewModel.Category = detail.ScheduleCategory;
            scheduleItemViewModel.ScheduleTime = detail.ScheduleTime;
            scheduleItemViewModel.RoomNumber = detail.RoomNumber;
            scheduleItemViewModel.UserStatus = detail.UserStatus;
            scheduleItemViewModel.Diagnosis = detail.Diagnosis;
            scheduleItemViewModel.ReferenceDetail = detail.ReferenceDetail;
            scheduleItemViewModel.ContactType = detail.ContactType;
            scheduleItemViewModel.DiagnosisGroup = detail.DiagnosisGroup;
            scheduleItemViewModel.HealthIssue = detail.HealthIssue;
            scheduleItemViewModel.TentativeDiagnosis = detail.TentativeDiagnosis;
            scheduleItemViewModel.ReferralReason = detail.ReferralReason;
            scheduleItemViewModel.LevelOfCare = detail.LevelOfCare;

            scheduleItemViewModel.UserInfo = new UserBasicInfoViewModel();
            scheduleItemViewModel.UserInfo.UserId = detail.UserInfo.UserId;
            scheduleItemViewModel.UserInfo.FirstName = detail.UserInfo.FirstName;
            scheduleItemViewModel.UserInfo.LastName = detail.UserInfo.LastName;
            scheduleItemViewModel.UserInfo.Gender = detail.UserInfo.Gender;
            scheduleItemViewModel.UserInfo.Surname = detail.UserInfo.Surname;
            scheduleItemViewModel.UserInfo.ReferenceNumber = detail.UserInfo.ReferenceNumber;
            scheduleItemViewModel.UserInfo.ContactNumber = detail.UserInfo.ContactNumber;
            scheduleItemViewModel.UserInfo.Email = detail.UserInfo.Email;

            List<UserAppointmentsViewModel> appointmentsList = new List<UserAppointmentsViewModel>();
            detail.UserAppointments.ForEach(c => appointmentsList.Add(new UserAppointmentsViewModel
            {
                AppointmentId = c.AppointmentId,
                DepartmentName = c.DepartmentName,
                AppointmentDescription = c.AppointmentDescription,
                AppointmentDateTime = c.AppointmentDate.Date == DateTime.Today ? "Today " + c.AppointmentDate.ToString("HH:mm") : c.AppointmentDate.Date.ToString("M.d") + " " + c.AppointmentDate.Date.ToString("HH:mm")
            }));

            scheduleItemViewModel.UserAppointments = appointmentsList;

            TimeSpan TS = DateTime.Now - detail.UserInfo.RegisteredDate;
            double years = TS.TotalDays / 365.25;

            scheduleItemViewModel.UserInfo.PatientSince = years + " Years";
            return scheduleItemViewModel;
        }
    }
}
