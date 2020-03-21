using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsSchedule.DataStore;
using DipsSchedule.Helpers;
using DipsSchedule.Models;
using DipsSchedule.ViewModels;

namespace DipsSchedule.Services
{
    public class ScheduleService : IScheduleService
    {
        private const int loopStartValue = -3;

        private const int loopEndValue = 4;

        private IScheduleDataStore _sheduleDataStore;

        public ScheduleService(IScheduleDataStore sheduleDataStore)
        {
            _sheduleDataStore = sheduleDataStore;
        }

        public async Task<List<ScheduleItemViewModel>> GetAllSchedules()
        {
            IEnumerable<ScheduleDetail> scheduleDetailList = await _sheduleDataStore.GetItemsAsync();

            List<ScheduleItemViewModel> scheduleItemList = new List<ScheduleItemViewModel>();

            foreach (ScheduleDetail detail in scheduleDetailList.ToList())
            {
                ScheduleItemViewModel scheduleItemViewModel = AddScheduleItem(detail);

                scheduleItemList.Add(scheduleItemViewModel);
            }

            return scheduleItemList;
        }

        public async Task<ScheduleItemViewModel> GetScheduleItem(int scheduleId)
        {
            ScheduleDetail detail = await _sheduleDataStore.GetItemAsync(scheduleId);

            ScheduleItemViewModel scheduleItemViewModel = AddScheduleItem(detail);

            return scheduleItemViewModel;
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
