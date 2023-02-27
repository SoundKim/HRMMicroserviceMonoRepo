using HRM.Onboard.ApplicationCore.Model.Request;
using HRM.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.ApplicationCore.Contract.Service
{
    public interface IEmployeeServiceAsync
    {
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
        Task<int> DeleteEmployeeAsync(int id);
        Task<EmployeeResponseModel> GetEmployeeByIdAsnc(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync();
    }
}
