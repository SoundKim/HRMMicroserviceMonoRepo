using HRM.Recruiting.ApplicationCore.Contract.Repository;
using HRM.Recruiting.ApplicationCore.Entity;
using HRM.Recruiting.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.Infrastructure.Repository
{
    public class SubmissionRepositoryAsync: BaseRepositoryAsync<Submission>, ISubmissionRepositoryAsync
    {
        public SubmissionRepositoryAsync(RecruitingDbContext _context): base(_context)
        {

        }
    }
}
