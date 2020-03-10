using System.Linq;
using System.Web.Http.Cors;
using MeetingManagementAPI.Data;
using MeetingManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeetingManagementAPI.Controllers
{
    // Allow CORS for all origins. (Caution!)
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "http://localhost:4200 ", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MeetingController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/meeting
        [HttpGet("GetMeetings")]
        public IActionResult GetMeetings()
        {
            return Ok(_db.MeetingDetails.ToList());
        }

        // GET api/meeting/5
        [HttpGet("GetMeeting/{Id}")]
        public IActionResult GetMeeting(int Id)
        {
            return Ok(_db.MeetingDetails.Where(x => x.MeetingID == Id).FirstOrDefault());
        }

        // POST api/meeting/createmeeting
        [HttpPost("CreateMeeting")]
        public IActionResult CreateMeeting(MeetingDetails details)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.MeetingDetails.Add(details);
            _db.SaveChanges();

            return Ok();
        }

        // PUT api/updatemeeting/5
        [HttpPut("UpdateMeeting/{meetingId}")]
        public IActionResult UpdateMeeting(int meetingId, MeetingDetails details)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            details.MeetingID = meetingId;

            //if (meetingId.ToString() != details.MeetingID.ToString())
            //{
            //   return BadRequest();
            // }

            // int MeetingID;
            // if(Int32.TryParse(details.MeetingID.ToString(),out MeetingID))


            _db.Entry(details).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingDetailExists(meetingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return Ok();

        }

        private bool MeetingDetailExists(int meetingid)
        {
            return _db.MeetingDetails.Count(x => x.MeetingID == meetingid) > 0;
        }
    }
}
