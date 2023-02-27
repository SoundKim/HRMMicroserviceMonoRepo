using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Contract.Service
{
    public interface IJobCategoryServiceAsync
    {
        Task<int> AddJobCategoryAsync(JobCategoryRequestModel model);
        Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model);
        Task<int> DeleteJobCategoryAsync(int id);
        Task<JobCategoryResponseModel> GetJobCategoryByIdAsnc(int id);
        Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategorysAsync();
    }
}
