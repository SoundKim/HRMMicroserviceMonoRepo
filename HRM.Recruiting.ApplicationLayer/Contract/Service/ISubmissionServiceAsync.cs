using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionServiceAsync
    {
        Task<int> AddSubmissionAsync(SubmissionResponseModel model);
        Task<int> UpdateSubmissionAsync(SubmissionResponseModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<SubmissionResponseModel> GetSubmissionByIdAsnc(int id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync();
    }
}
