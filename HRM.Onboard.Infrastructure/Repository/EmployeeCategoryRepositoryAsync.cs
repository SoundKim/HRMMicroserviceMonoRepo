using HRM.Onboard.ApplicationCore.Contract.Repository;
using HRM.Onboard.ApplicationCore.Entity;
using HRM.Onboard.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.Infrastructure.Repository
{
    public class EmployeeCategoryRepositoryAsync: BaseRepositoryAsync<EmployeeCategory>, IEmployeeCategoryRepositoryAsync
    {
        public EmployeeCategoryRepositoryAsync(OnboardDbContext _context): base(_context)
        {

        }
    }
}
