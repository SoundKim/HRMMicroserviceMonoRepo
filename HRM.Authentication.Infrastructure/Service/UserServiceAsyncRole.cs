using HRM.Authentication.Infrastructure.Contract.Repository;
using HRM.Authentication.Infrastructure.Contract.Service;
using HRM.Authentication.Infrastructure.Entity;
using HRM.Authentication.Infrastructure.Model.Request;
using HRM.Authentication.Infrastructure.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Service
{
    public class RoleServiceAsync : IRoleServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IRoleRepositoryAsync roleRepositoryAsync;
        public RoleServiceAsync(IRoleRepositoryAsync _roleRepositoryAsync)
        {
            roleRepositoryAsync = _roleRepositoryAsync;
        }

        public async Task<int> AddRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description

            };
            return await roleRepositoryAsync.InsertAsync(role);
        }

        public async Task<int> DeleteRoleAsync(int Id)
        {
            return await roleRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync()
        {
            var result = await roleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new RoleResponseModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description

                });
            }
            return null;
        }

        public async Task<RoleResponseModel> GetRoleByIdAsnc(int Id)
        {
            var model = await roleRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new RoleResponseModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description

                };
            }
            return null;
        }

        public Task<int> UpdateRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description

            };
            return roleRepositoryAsync.UpdateAsync(role);
        }
    }
}
