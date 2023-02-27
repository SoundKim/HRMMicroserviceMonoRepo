using HRM.Authentication.ApplicationCore.Data;
using HRM.Authentication.Infrastructure.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> 
    {
        protected readonly AuthenticationDbContext db;
        public BaseRepositoryAsync(AuthenticationDbContext _context)
        {
            db = _context;
        }

    }
}
