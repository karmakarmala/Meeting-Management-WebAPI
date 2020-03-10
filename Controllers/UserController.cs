using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using MeetingManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MeetingManagementAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/user/getusers
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_db.UserDetails.ToList());
        }
    }
}
