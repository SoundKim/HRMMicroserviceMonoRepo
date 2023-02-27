using HRM.Onboard.ApplicationCore.Contract.Repository;
using HRM.Onboard.ApplicationCore.Contract.Service;
using HRM.Onboard.ApplicationCore.Entity;
using HRM.Onboard.ApplicationCore.Model.Request;
using HRM.Onboard.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Onboard.Infrastructure.Service
{
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }
        public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                HireDate = model.HireDate,
                EndDate = model.EndDate,
                EmployeeCategoryId = model.EmployeeCategoryId,
                EmployeeStatusId = model.EmployeeStatusId,
                EmployeeRoleId = model.EmployeeRoleId,
                Address = model.Address,
                EmailId = model.EmailId
            };
            return await employeeRepositoryAsync.InsertAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(int Id)
        {
            return employeeRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SSN = model.SSN,
                    HireDate = model.HireDate,
                    EndDate = model.EndDate,
                    EmployeeCategoryId = model.EmployeeCategoryId,
                    EmployeeStatusId = model.EmployeeStatusId,
                    EmployeeRoleId = model.EmployeeRoleId,
                    Address = model.Address,
                    EmailId = model.EmailId
                });
            }

            return null;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsnc(int Id)
        {
            var model = await employeeRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SSN = model.SSN,
                    HireDate = model.HireDate,
                    EndDate = model.EndDate,
                    EmployeeCategoryId = model.EmployeeCategoryId,
                    EmployeeStatusId = model.EmployeeStatusId,
                    EmployeeRoleId = model.EmployeeRoleId,
                    Address = model.Address,
                    EmailId = model.EmailId
                };
            }
            return null;
        }

        public Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                SSN = model.SSN,
                HireDate = model.HireDate,
                EndDate = model.EndDate,
                EmployeeCategoryId = model.EmployeeCategoryId,
                EmployeeStatusId = model.EmployeeStatusId,
                EmployeeRoleId = model.EmployeeRoleId,
                Address = model.Address,
                EmailId = model.EmailId
            };
            return employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}
