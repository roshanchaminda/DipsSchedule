using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DipsSchedule.ViewModels;

namespace DipsSchedule.Services
{
    /// <summary>
    /// Invoke schedule service call 
    /// </summary>
    public interface IScheduleService
    {
        /// <summary>
        /// Will allow a <c>Task</c> to be execute asynchronously for get current week data
        /// </summary>
        /// <returns>A <c><List<DateCellViewModel>></c> object</returns>
        Task<List<DateCellViewModel>> GetCurrentWeekData();

        /// <summary>
        /// Will allow a <c>Task</c> to be execute asynchronously for get all schedule data
        /// </summary>
        /// <returns>A <c><List<ScheduleItemViewModel>></c> object</returns>
        Task<List<ScheduleItemViewModel>> GetAllSchedules();

        /// <summary>
        /// Will allow a <c>Task</c> to be execute asynchronously for get schedule data by ScheduleId
        /// </summary>
        /// <param name="scheduleId">The SheduleID to be executed</param>
        /// <returns>A <c><ScheduleItemViewModel></c> object</returns>
        Task<ScheduleItemViewModel> GetScheduleItem(int scheduleId);
    }
}
