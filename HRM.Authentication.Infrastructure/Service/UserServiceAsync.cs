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
    public class UserServiceAsync : IUserServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IUserRepositoryAsync userRepositoryAsync;
        public UserServiceAsync(IUserRepositoryAsync _userRepositoryAsync)
        {
            userRepositoryAsync = _userRepositoryAsync;
        }

        public async Task<int> AddUserAsync(UserRequestModel model)
        {
            Account user = new Account()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                EmailId = model.EmailId,
                RoleId = model.RoleId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password

            };
            return await userRepositoryAsync.InsertAsync(user);
        }

        public async Task<int> DeleteUserAsync(int Id)
        {
            return await userRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            var result = await userRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new UserResponseModel
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    EmailId = model.EmailId,
                    RoleId = model.RoleId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password
                });
            }
            return null;
        }

        public async Task<UserResponseModel> GetUserByIdAsnc(int Id)
        {
            var model = await userRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new UserResponseModel()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    EmailId = model.EmailId,
                    RoleId = model.RoleId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password
                };
            }
            return null;
        }

        public Task<int> UpdateUserAsync(UserRequestModel model)
        {
            Account user = new Account()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                EmailId = model.EmailId,
                RoleId = model.RoleId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password
            };
            return userRepositoryAsync.UpdateAsync(user);
        }
    }
}
