using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Contract.Service
{
    public interface IJobRequirementServiceAsync
    {
        Task<int> AddJobRequirementAsync(JobRequirementResponseModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementResponseModel model);
        Task<int> DeleteJobRequirementAsync(int id);
        Task<JobRequirementResponseModel> GetJobRequirementByIdAsnc(int id);
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementsAsync();
    }
}
