using System;
namespace DipsSchedule.Models
{
    public class UserAppointments
    {
        public int AppointmentId { get; set; }

        public string DepartmentName { get; set; }

        public string AppointmentDescription { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int UserId { get; set; }
    }
}
