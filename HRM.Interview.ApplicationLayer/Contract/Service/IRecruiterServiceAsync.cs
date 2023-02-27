using HRM.Interview.ApplicationCore.Model.Request;
using HRM.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Contract.Service
{
    public interface IRecruiterServiceAsync
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
        Task<int> DeleteRecruiterAsync(int id);
        Task<RecruiterResponseModel> GetRecruiterByIdAsnc(int id);
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync();
    }
}
