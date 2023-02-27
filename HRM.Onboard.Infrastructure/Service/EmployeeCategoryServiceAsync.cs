using HRM.Onboard.ApplicationCore.Contract.Repository;
using HRM.Onboard.ApplicationCore.Contract.Service;
using HRM.Onboard.ApplicationCore.Entity;
using HRM.Onboard.ApplicationCore.Model.Request;
using HRM.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.Infrastructure.Service
{
    public class EmployeeCategoryServiceAsync : IEmployeeCategoryServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IEmployeeCategoryRepositoryAsync employeeCategoryRepositoryAsync;
        public EmployeeCategoryServiceAsync(IEmployeeCategoryRepositoryAsync _employeeCategoryRepositoryAsync)
        {
            employeeCategoryRepositoryAsync = _employeeCategoryRepositoryAsync;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory employeeCategory = new EmployeeCategory()
            {
               Id = model.Id,
               Title = model.Title,
               Description = model.Description,
               IsActive = model.IsActive
            };
            return await employeeCategoryRepositoryAsync.InsertAsync(employeeCategory);
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int Id)
        {
            return await employeeCategoryRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategorysAsync()
        {
            var result = await employeeCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeCategoryResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsnc(int Id)
        {
            var result = await employeeCategoryRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new EmployeeCategoryResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            EmployeeCategory employeeCategory = new EmployeeCategory()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeCategoryRepositoryAsync.UpdateAsync(employeeCategory);
        }
    }
}
