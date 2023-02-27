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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
               Id = model.Id,
               Title = model.Title,
               Description = model.Description,
               IsActive = model.IsActive
            };
            return await interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public async Task<int> DeleteInterviewTypeAsync(int Id)
        {
            return await interviewTypeRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewTypeResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsnc(int Id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return interviewTypeRepositoryAsync.UpdateAsync(interviewType);
        }
    }
}
