using System;
namespace DipsSchedule.Models
{
    public class User
    {
        public User()
        {
        }

        public int UserId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime RegisteredDate { get; set; }

        public string ReferenceNumber { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }
    }
}
