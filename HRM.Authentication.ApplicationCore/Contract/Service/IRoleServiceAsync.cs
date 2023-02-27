using HRM.Authentication.Infrastructure.Model.Request;
using HRM.Authentication.Infrastructure.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Contract.Service
{
    public interface IRoleServiceAsync
    {
        Task<int> AddRoleAsync(RoleRequestModel model);
        Task<int> UpdateRoleAsync(RoleRequestModel model);
        Task<int> DeleteRoleAsync(int id);
        Task<RoleResponseModel> GetRoleByIdAsnc(int id);
        Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync();
    }
}
