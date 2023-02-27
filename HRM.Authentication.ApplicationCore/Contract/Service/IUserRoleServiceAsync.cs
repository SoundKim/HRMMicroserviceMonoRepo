using HRM.Authentication.Infrastructure.Model.Request;
using HRM.Authentication.Infrastructure.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Contract.Service
{
    public interface IUserRoleServiceAsync
    {
        Task<int> AddUserRoleAsync(UserRoleRequestModel model);
        Task<int> UpdateUserRoleAsync(UserRoleRequestModel model);
        Task<int> DeleteUserRoleAsync(int id);
        Task<UserRoleResponseModel> GetUserRoleByIdAsnc(int id);
        Task<IEnumerable<UserRoleResponseModel>> GetAllUserRolesAsync();
    }
}
