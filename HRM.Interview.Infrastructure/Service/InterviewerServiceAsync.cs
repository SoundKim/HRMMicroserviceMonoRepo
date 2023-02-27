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
    public class InterviewerServiceAsync : IInterviewerServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IInterviewerRepositoryAsync interviewerRepositoryAsync;
        public InterviewerServiceAsync(IInterviewerRepositoryAsync _interviewerRepositoryAsync)
        {
            interviewerRepositoryAsync = _interviewerRepositoryAsync;
        }

        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer interviewer = new Interviewer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };
            return await interviewerRepositoryAsync.InsertAsync(interviewer);
        }

        public async Task<int> DeleteInterviewerAsync(int Id)
        {
            return await interviewerRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewersAsync()
        {
            var result = await interviewerRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewerResponseModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId
                });
            }
            return null;
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsnc(int Id)
        {
            var model = await interviewerRepositoryAsync.GetByIdAsync(Id);
            if(model !=null)
            { 
                return new InterviewerResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmployeeId = model.EmployeeId
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            Interviewer interviewer = new Interviewer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };
            return interviewerRepositoryAsync.UpdateAsync(interviewer);
        }
    }
}
