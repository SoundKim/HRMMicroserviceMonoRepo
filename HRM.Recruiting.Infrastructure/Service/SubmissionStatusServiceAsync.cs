using HRM.Recruiting.ApplicationCore.Contract.Repository;
using HRM.Recruiting.ApplicationCore.Contract.Service;
using HRM.Recruiting.ApplicationCore.Entity;
using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.Infrastructure.Service
{
    public class SubmissionStatusServiceAsync : ISubmissionStatusServiceAsync
    {
   
        private readonly ISubmissionStatusRepositoryAsync SubmissionStatusRepositoryAsync;
        public SubmissionStatusServiceAsync(ISubmissionStatusRepositoryAsync _SubmissionStatusRepositoryAsync)
        {
            SubmissionStatusRepositoryAsync = _SubmissionStatusRepositoryAsync;
        }

        public async Task<int> AddSubmissionStatusAsync(SubmissionStatusResponseModel model)
        {
            SubmissionStatus SubmissionStatus = new SubmissionStatus()
            {
               Id = model.Id,
               Title = model.Title,
               IsActive = model.IsActive
            };
            return await SubmissionStatusRepositoryAsync.InsertAsync(SubmissionStatus);
        }

        public async Task<int> DeleteSubmissionStatusAsync(int Id)
        {
            return await SubmissionStatusRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatussAsync()
        {
            var result = await SubmissionStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new SubmissionStatusResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsnc(int Id)
        {
            var result = await SubmissionStatusRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new SubmissionStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionStatusAsync(SubmissionStatusResponseModel model)
        {
            SubmissionStatus SubmissionStatus = new SubmissionStatus()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return SubmissionStatusRepositoryAsync.UpdateAsync(SubmissionStatus);
        }
    }
}
