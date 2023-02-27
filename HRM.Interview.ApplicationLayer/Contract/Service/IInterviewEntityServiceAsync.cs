using HRM.Interview.ApplicationCore.Model.Request;
using HRM.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewEntityServiceAsync
    {
        Task<int> AddInterviewEntityAsync(InterviewEntityRequestModel model);
        Task<int> UpdateInterviewEntityAsync(InterviewEntityRequestModel model);
        Task<int> DeleteInterviewEntityAsync(int id);
        Task<InterviewEntityResponseModel> GetInterviewEntityByIdAsnc(int id);
        Task<IEnumerable<InterviewEntityResponseModel>> GetAllInterviewEntitysAsync();
    }
}
