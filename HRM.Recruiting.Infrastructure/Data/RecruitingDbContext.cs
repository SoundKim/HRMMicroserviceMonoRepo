using HRM.Recruiting.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.Infrastructure.Data
{
    public class RecruitingDbContext: DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> option): base(option)
        {

        }

        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<JobRequirement> JobRequirement { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Submission> Submission { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    }
}
