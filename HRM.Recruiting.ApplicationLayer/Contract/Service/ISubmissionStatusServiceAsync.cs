using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionStatusServiceAsync
    {
        Task<int> AddSubmissionStatusAsync(SubmissionStatusResponseModel model);
        Task<int> UpdateSubmissionStatusAsync(SubmissionStatusResponseModel model);
        Task<int> DeleteSubmissionStatusAsync(int id);
        Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsnc(int id);
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatussAsync();
    }
}
