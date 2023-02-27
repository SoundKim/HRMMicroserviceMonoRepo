using HRM.Authentication.Infrastructure.Contract.Repository;
using HRM.Authentication.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HRM.Authentication.ApplicationCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRM.Authentication.Infrastructure.Repository
{

    public class UserRepositoryAsync :  IUserRepositoryAsync
    {
        AuthenticationDbContext dbContext;
        public UserRepositoryAsync()
        {
            dbContext = new AuthenticationDbContext();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Delete From Account where Id = @Id";
                var parameters = new { Id = id };
                return conn.Execute(sql, parameters);
            }
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select Id, EmployeeId, EmailId, RoleId, FirstName, LastName, Password from Account";
                return conn.Query<Account>(sql);
            }
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select  Id, EmployeeId, EmailId, RoleId, FirstName, LastName, Password From Account where Id = @Id";
                var parameters = new { Id = id };
                return conn.QuerySingleOrDefault<Account>(sql, parameters);
            }
        }

        public async Task<int> InsertAsync(Account entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Insert Into Account (EmployeeId, EmailId, RoleId, FirstName, LastName, Password) values (@EmployeeId, @EmailId, @RoleId, @FirstName, @LastName, @Password)";
                return conn.Execute(sql, entity);
            }
        }

        public async Task<int> UpdateAsync(Account entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Execute("Update Account set EmployeeId = @EmployeeId, EmailId = @EmailId, RoleId = @RoleId, FirstName = @FirstName,LastName = @LastName,Password = @Password where Id = @id", entity);
            }
        }
    }
}
