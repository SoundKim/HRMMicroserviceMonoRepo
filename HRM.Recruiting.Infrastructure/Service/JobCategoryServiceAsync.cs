﻿using HRM.Recruiting.ApplicationCore.Contract.Repository;
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
    public class JobCategoryServiceAsync : IJobCategoryServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IJobCategoryRepositoryAsync jobCategoryRepositoryAsync;
        public JobCategoryServiceAsync(IJobCategoryRepositoryAsync _jobCategoryRepositoryAsync)
        {
            jobCategoryRepositoryAsync = _jobCategoryRepositoryAsync;
        }

        public async Task<int> AddJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
               Id = model.Id,
               Title = model.Title,
               Description = model.Description,
               IsActive = model.IsActive
            };
            return await jobCategoryRepositoryAsync.InsertAsync(jobCategory);
        }

        public async Task<int> DeleteJobCategoryAsync(int Id)
        {
            return await jobCategoryRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategorysAsync()
        {
            var result = await jobCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new JobCategoryResponseModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    IsActive = model.IsActive
                });
            }
            return null;
        }

        public async Task<JobCategoryResponseModel> GetJobCategoryByIdAsnc(int Id)
        {
            var result = await jobCategoryRepositoryAsync.GetByIdAsync(Id);
            if(result !=null)
            { 
                return new JobCategoryResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.UpdateAsync(jobCategory);
        }
    }
}
