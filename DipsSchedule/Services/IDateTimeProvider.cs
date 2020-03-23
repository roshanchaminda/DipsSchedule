using System;

namespace DipsSchedule.Services
{
    /// <summary>
    /// This will return DateTime.Now instance 
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
