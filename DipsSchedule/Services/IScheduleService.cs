using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DipsSchedule.ViewModels;

namespace DipsSchedule.Services
{
    /// <summary>
    /// Invoke data request service calls from the ViewModel 
    /// </summary>
    public interface IScheduleService
    {
        /// <summary>
        /// Will be executed asynchronously to get current week data
        /// </summary>
        /// <returns>A <c><List<DateCellViewModel>></c> object</returns>
        Task<List<DateCellViewModel>> GetCurrentWeekData();

        /// <summary>
        /// Will be executed asynchronously to get all schedule data
        /// </summary>
        /// <returns>A <c><List<ScheduleItemViewModel>></c> object</returns>
        Task<List<ScheduleItemViewModel>> GetAllSchedules();

        /// <summary>
        /// Will be executed asynchronously for get schedule data by ScheduleId
        /// </summary>
        /// <param name="scheduleId">The SheduleID to be executed</param>
        /// <returns>A <c><ScheduleItemViewModel></c> object</returns>
        Task<ScheduleItemViewModel> GetScheduleItem(int scheduleId);
    }
}
