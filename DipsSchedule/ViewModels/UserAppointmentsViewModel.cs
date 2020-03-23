using System;
using DipsSchedule.ViewModels.Base;

namespace DipsSchedule.ViewModels
{
    public class UserAppointmentsViewModel : ViewModelBase
    {
        public int AppointmentId { get; set; }

        public string DepartmentName { get; set; }

        public string AppointmentDescription { get; set; }

        public string AppointmentDateTime { get; set; }
    }
}
