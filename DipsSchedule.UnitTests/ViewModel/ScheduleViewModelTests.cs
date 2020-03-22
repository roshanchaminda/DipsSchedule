using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsSchedule.Enums;
using DipsSchedule.Models;
using DipsSchedule.Services;
using DipsSchedule.UnitTests.Mocks.Services;
using DipsSchedule.ViewModels;
using DipsSchedule.ViewModels.Base;
using Moq;
using Xunit;

namespace DipsSchedule.UnitTests.ViewModel
{
    public class ScheduleViewModelTests
    {
        private readonly Mock<INavigationService> _navigationServiceMock = new Mock<INavigationService>();
        private readonly Mock<IScheduleService> _scheduleServiceMock = new Mock<IScheduleService>();

        private readonly ScheduleViewModel _scheduleViewModel;

        public ScheduleViewModelTests()
        {
            _scheduleViewModel = new ScheduleViewModel(_scheduleServiceMock.Object, _navigationServiceMock.Object);
        }

        [Fact]
        public async void InitializeAsync_Default_LoadScheduleInvoked()
        {
            _scheduleServiceMock.Setup(scheduleService => scheduleService.GetCurrentWeekData()).Returns(Task.FromResult(new List<DateCellViewModel>()));
            _scheduleServiceMock.Setup(scheduleService => scheduleService.GetAllSchedules()).Returns(Task.FromResult(new List<ScheduleItemViewModel>()));

            await _scheduleViewModel.InitializeAsync(new { });

            _scheduleServiceMock.Verify(scheduleService => scheduleService.GetAllSchedules(), Times.Once);
        }

        [Fact]
        public void DaySelectCommand_Invoked_ReturnEmpty()
        {
            List<DateCellViewModel> weekDataList = GetCurrentWeekData();
            weekDataList.ForEach(_scheduleViewModel.WeekDaysView.Add);

            _scheduleViewModel.SheduleList = GetScheduleList();

            _scheduleViewModel.DaySelectCommand.Execute(1);

            Assert.Equal(_scheduleViewModel.WeekDaysView[0].DateValue.Date, _scheduleViewModel.SheduleList[0].ScheduleDate.Date);

        }

        [Fact]
        public void ScheduleSelectCommand_Invoked_NavigationServiceInvoked()
        {
            _scheduleServiceMock.Setup(scheduleService => scheduleService.GetScheduleItem(It.IsAny<int>()))
                .Returns(Task.FromResult(GetScheduleItemViewModel()));

            _scheduleViewModel.ScheduleSelectCommand.Execute(23);

            _navigationServiceMock.Verify(ns => ns.NavigateToAsync<ScheduleDetailViewModel>(), Times.Once);
        }

        private static ScheduleItemViewModel GetScheduleItemViewModel()
        {
            var scheduleDetail = new ScheduleItemViewModel()
            {

            };

            return scheduleDetail;
        }

        private static List<DateCellViewModel> GetCurrentWeekData()
        {
            List<DateCellViewModel> weekDaysViewList = new List<DateCellViewModel>();

            for (int i = -3; i < 7; i++)
            {
                DateCellViewModel dateCell = new DateCellViewModel();
                dateCell.DateValue = DateTime.Now.AddDays(i);
                dateCell.IsSelectedCell = i == 0 ? true : false;
                dateCell.DateCellIndex = i + -3 * -1;

                weekDaysViewList.Add(dateCell);
            }

            return weekDaysViewList;
        }

        private static List<ScheduleItemViewModel> GetScheduleList()
        {
            List<ScheduleItemViewModel> scheduleItemList = new List<ScheduleItemViewModel>();

            List<ScheduleDetail> scheduleDetailList = ScheduleDetails;

            foreach (ScheduleDetail detail in scheduleDetailList)
            {
                ScheduleItemViewModel scheduleItemViewModel = AddScheduleItem(detail);

                scheduleItemList.Add(scheduleItemViewModel);
            }

            return scheduleItemList;
        }

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
            }
        };

        public static List<ScheduleDetail> ScheduleDetails = new List<ScheduleDetail>()
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
                ScheduleDetailId = 2,
                UserInfo=Users[0],
                ScheduleDate=DateTime.Now.AddDays(-2),
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
            }
        };



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
