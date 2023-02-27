using HRM.Interview.ApplicationCore.Model.Request;
using HRM.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewerServiceAsync
    {
        Task<int> AddInterviewerAsync(InterviewerRequestModel model);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
        Task<int> DeleteInterviewerAsync(int id);
        Task<InterviewerResponseModel> GetInterviewerByIdAsnc(int id);
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewersAsync();
    }
}
