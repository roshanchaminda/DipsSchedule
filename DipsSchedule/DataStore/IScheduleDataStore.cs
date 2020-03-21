using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DipsSchedule.Models;

namespace DipsSchedule.DataStore
{
    public interface IScheduleDataStore
    {
        Task<ScheduleDetail> GetItemAsync(int id);

        Task<IEnumerable<ScheduleDetail>> GetItemsAsync();
    }
}
