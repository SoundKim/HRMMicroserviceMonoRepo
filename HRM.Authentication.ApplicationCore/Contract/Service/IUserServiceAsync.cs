using HRM.Authentication.Infrastructure.Model.Request;
using HRM.Authentication.Infrastructure.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Contract.Service
{
    public interface IUserServiceAsync
    {
        Task<int> AddUserAsync(UserRequestModel model);
        Task<int> UpdateUserAsync(UserRequestModel model);
        Task<int> DeleteUserAsync(int id);
        Task<UserResponseModel> GetUserByIdAsnc(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();
    }
}
