using HRM.Interview.ApplicationCore.Contract.Repository;
using HRM.Interview.ApplicationCore.Entity;
using HRM.Interview.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.Infrastructure.Repository
{
    public class InterviewerRepositoryAsync : BaseRepositoryAsync<Interviewer>, IInterviewerRepositoryAsync
    {
        public InterviewerRepositoryAsync(InterviewDbContext _context) : base(_context)
        {
        }
    }
}
