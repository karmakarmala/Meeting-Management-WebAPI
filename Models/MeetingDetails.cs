using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingManagementAPI.Models
{
    public class MeetingDetails
    {
        [Key]
        public int MeetingID { get; set; }
        public string MeetingSubject { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingAttendees { get; set; }
        public string MeetingTime { get; set; }


    }
}
