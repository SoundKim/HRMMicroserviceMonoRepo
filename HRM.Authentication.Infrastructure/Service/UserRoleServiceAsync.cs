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
    public class UserRoleServiceAsync : IUserRoleServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IUserRoleRepositoryAsync userRoleRepositoryAsync;
        public UserRoleServiceAsync(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
        {
            userRoleRepositoryAsync = _userRoleRepositoryAsync;
        }

        public async Task<int> AddUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                Id = model.Id,
                UserId = model.UserId,
                RoleId = model.RoleId

            };
            return await userRoleRepositoryAsync.InsertAsync(userRole);
        }

        public async Task<int> DeleteUserRoleAsync(int Id)
        {
            return await userRoleRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRolesAsync()
        {
            var result = await userRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new UserRoleResponseModel
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoleId = model.RoleId

                });
            }
            return null;
        }

        public async Task<UserRoleResponseModel> GetUserRoleByIdAsnc(int Id)
        {
            var model = await userRoleRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new UserRoleResponseModel()
                {
                    Id = model.Id,
                    UserId = model.UserId,
                    RoleId = model.RoleId

                };
            }
            return null;
        }

        public Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                Id = model.Id,
                UserId = model.UserId,
                RoleId = model.RoleId

            };
            return userRoleRepositoryAsync.UpdateAsync(userRole);
        }
    }
}
