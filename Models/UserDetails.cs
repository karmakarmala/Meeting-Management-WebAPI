using System.ComponentModel.DataAnnotations;

namespace MeetingManagementAPI.Models
{
    public class UserDetails
    {
        [Key]
        public int ID { get; set; }
        public string LoginID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}
