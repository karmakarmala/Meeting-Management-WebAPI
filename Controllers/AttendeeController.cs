using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingManagementAPI.Data;
using MeetingManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MeetingManagementAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AttendeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/attendee/getattendees
        [HttpGet("GetAttendees")]
        public IActionResult GetAttendees()
        {
            //var attendees = _db.AttendeeDetails;

            //var attendeeNames = (from attendee in attendees
            //                     select new
            //                     {
            //                         name = attendee.AttendeeName
            //                     }).ToList();

            //return Ok(attendeeNames);

            return Ok(GetAttendeesList());
        }

        //GET: api/attendee/getmeetingreport
        [HttpGet("GetMeetingReport")]
        public IActionResult GetMeetingReport()
        {
            var meetingLists = _db.MeetingDetails.ToList();

            var meetingAttendees = (from meetingList in meetingLists
                                    select new
                                    {
                                        attendeeNames = meetingList.MeetingAttendees
                                    }).ToList();

            var attendeeLists = GetAttendeesList();

            var report = new List<MeetingReport>();

            for (int i = 0; i < attendeeLists.Count; i++)
            {
                var name = attendeeLists[i].ToString();
                int attendeeCount = 0;
                foreach (var attendee in meetingAttendees)
                {
                    if (attendee.attendeeNames.Contains(name))
                        attendeeCount = attendeeCount + 1;
                }
                report.Add(new MeetingReport() { AttendeeName = name, ReportCount = attendeeCount });
            }

            return Ok(report.ToList());
        }

        public List<string> GetAttendeesList()
        {
            var attendees = _db.AttendeeDetails;

            var attendeeNames = (from attendee in attendees
                                 select new
                                 {
                                     name = attendee.AttendeeName
                                 }).ToList();
            List<string> result = new List<string>();

            foreach (var attendeeName in attendeeNames)
            {
                result.Add(attendeeName.name);
            }
            return result;
        }



    }
}
