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

namespace HRM.Authentication.Infrastructure.Repository
{

    public class UserRoleRepositoryAsync : IUserRoleRepositoryAsync
    {
        AuthenticationDbContext dbContext;
        public UserRoleRepositoryAsync()
        {
            dbContext = new AuthenticationDbContext();
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Delete From UserRole where Id = @Id";
                var parameters = new { Id = id };
                return conn.Execute(sql, parameters);
            }
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select Id, UserId, RoleId from UserRole";
                return conn.Query<UserRole>(sql);
            }
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select  Id, UserId, RoleId From UserRole where Id = @Id";
                var parameters = new { Id = id };
                return conn.QuerySingleOrDefault<UserRole>(sql, parameters);
            }
        }

        public async Task<int> InsertAsync(UserRole entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Insert Into UserRole (UserId, RoleId) values (@UserId, @RoleId)";
                return conn.Execute(sql, entity);
            }
        }

        public async Task<int> UpdateAsync(UserRole entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Execute("Update UserRole set UserId = @UserId, RoleId = @RoleId where Id = @id", entity);
            }
        }
    }
}
