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
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private readonly IJobRequirementRepositoryAsync jobRequirementRepositoryAsync;
        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync)
        {
            jobRequirementRepositoryAsync = _jobRequirementRepositoryAsync;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementResponseModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                TotalPosition = model.TotalPosition,
                Description = model.Description,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                CreatedOn = model.CreatedOn,
                StartDate = model.StartDate,
                ClosedOn = model.ClosedOn,
                IsActive = model.IsActive,
                ClosingReason = model.ClosingReason,
                JobCategoryId = model.JobCategoryId
            };
            return await jobRequirementRepositoryAsync.InsertAsync(jobRequirement);
        }

        public async Task<int> DeleteJobRequirementAsync(int Id)
        {
            return await jobRequirementRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementsAsync()
        {
            var result = await jobRequirementRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new JobRequirementResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    TotalPosition = model.TotalPosition,
                    Description = model.Description,
                    HiringManagerId = model.HiringManagerId,
                    HiringManagerName = model.HiringManagerName,
                    CreatedOn = model.CreatedOn,
                    StartDate = model.StartDate,
                    ClosedOn = model.ClosedOn,
                    IsActive = model.IsActive,
                    ClosingReason = model.ClosingReason,
                    JobCategoryId = model.JobCategoryId
                });
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsnc(int Id)
        {
            var model = await jobRequirementRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new JobRequirementResponseModel()
                {
                    Id = model.Id,
                    Title = model.Title,
                    TotalPosition = model.TotalPosition,
                    Description = model.Description,
                    HiringManagerId = model.HiringManagerId,
                    HiringManagerName = model.HiringManagerName,
                    CreatedOn = model.CreatedOn,
                    StartDate = model.StartDate,
                    ClosedOn = model.ClosedOn,
                    IsActive = model.IsActive,
                    ClosingReason = model.ClosingReason,
                    JobCategoryId = model.JobCategoryId
                };
            }
            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementResponseModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                TotalPosition = model.TotalPosition,
                Description = model.Description,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                CreatedOn = model.CreatedOn,
                StartDate = model.StartDate,
                ClosedOn = model.ClosedOn,
                IsActive = model.IsActive,
                ClosingReason = model.ClosingReason,
                JobCategoryId = model.JobCategoryId
            };
            return jobRequirementRepositoryAsync.UpdateAsync(jobRequirement);
        }
    }
}
