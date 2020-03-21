using System;
using DipsSchedule.ViewModels.Base;
using Xamarin.Forms;

namespace DipsSchedule.ViewModels
{
    public class UserBasicInfoViewModel : ViewModelBase
    {
        public UserBasicInfoViewModel()
        {
        }

        public int UserId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string PatientSince { get; set; }

        public string ReferenceNumber { get; set; }
    }
}
