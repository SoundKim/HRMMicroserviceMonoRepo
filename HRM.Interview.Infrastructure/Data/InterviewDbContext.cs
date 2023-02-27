using HRM.Interview.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.Infrastructure.Data
{
    public class InterviewDbContext: DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> option): base(option)
        {

        }

        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<InterviewEntity> InterviewEntity { get; set; }
        public DbSet<InterviewType> InterviewType { get; set; }
        public DbSet<Interviewer> Interviewer { get; set; }
        public DbSet<Recruiter> Recruiter { get; set; }
    }
}
