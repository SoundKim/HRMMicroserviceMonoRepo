using HRM.Authentication.Infrastructure.Contract.Repository;
using HRM.Authentication.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HRM.Authentication.ApplicationCore.Data;

namespace HRM.Authentication.Infrastructure.Repository
{

    public class RoleRepositoryAsync : IRoleRepositoryAsync
    {
        AuthenticationDbContext dbContext;
        public RoleRepositoryAsync()
        {
            dbContext = new AuthenticationDbContext();
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Delete From Role where Id = @Id";
                var parameters = new { Id = id };
                return conn.Execute(sql, parameters);
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select Id, Name, Description from Role";
                return conn.Query<Role>(sql);
            }
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Select Id, Name, Description From Role where Id = @Id";
                var parameters = new { Id = id };
                return conn.QuerySingleOrDefault<Role>(sql, parameters);
            }
        }

        public async Task<int> InsertAsync(Role entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                string sql = "Insert Into Role(Name, Description) values (@Name, @Description)";
                return conn.Execute(sql, entity);
            }
        }

        public async Task<int> UpdateAsync(Role entity)
        {
            using (var conn = dbContext.GetConnection())
            {
                return conn.Execute("Update Role set Name = @Name, @Description = Description where Id = @id", entity);
            }
        }

    }
}
