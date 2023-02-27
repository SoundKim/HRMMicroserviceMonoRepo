using HRM.Onboard.ApplicationCore.Model.Request;
using HRM.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.ApplicationCore.Contract.Service
{
    public interface IEmployeeStatusServiceAsync
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsnc(int id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatussAsync();
    }
}
