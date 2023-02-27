using HRM.Interview.ApplicationCore.Contract.Repository;
using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Entity;
using HRM.Interview.ApplicationCore.Model.Request;
using HRM.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.Infrastructure.Service
{
    public class RecruiterServiceAsync : IRecruiterServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IRecruiterRepositoryAsync recruiterRepositoryAsync;
        public RecruiterServiceAsync(IRecruiterRepositoryAsync _recruiterRepositoryAsync)
        {
            recruiterRepositoryAsync = _recruiterRepositoryAsync;
        }

        public async Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter recruiter = new Recruiter()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };
            return await recruiterRepositoryAsync.InsertAsync(recruiter);
        }

        public async Task<int> DeleteRecruiterAsync(int Id)
        {
            return await recruiterRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync()
        {
            var result = await recruiterRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new RecruiterResponseModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId
                });
            }
            return null;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsnc(int Id)
        {
            var model = await recruiterRepositoryAsync.GetByIdAsync(Id);
            if(model !=null)
            { 
                return new RecruiterResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId
                };
            }
            return null;
        }

        public Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter recruiter = new Recruiter()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };
            return recruiterRepositoryAsync.UpdateAsync(recruiter);
        }
    }
}
