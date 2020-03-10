using System;
using Microsoft.EntityFrameworkCore;
using MeetingManagementAPI.Models;


namespace MeetingManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<MeetingDetails> MeetingDetails { get; set; }
        public DbSet<AttendeeDetails> AttendeeDetails { get; set; }
        //public DbSet<MeetingReport> MeetingReport { get; set; }
    }
}
