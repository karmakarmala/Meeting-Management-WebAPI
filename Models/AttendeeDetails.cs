using System.ComponentModel.DataAnnotations;

namespace MeetingManagementAPI.Models
{
    public class AttendeeDetails
    {
        [Key]
        public int AttendeeID { get; set; }
        public string AttendeeName { get; set; }
    }
}
