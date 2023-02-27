using HRM.Onboard.ApplicationCore.Model.Request;
using HRM.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.ApplicationCore.Contract.Service
{
    public interface IEmployeeCategoryServiceAsync
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsnc(int id);
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorysAsync();
    }
}
