using HRM.Interview.ApplicationCore.Contract.Repository;
using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Entity;
using HRM.Interview.ApplicationCore.Model.Request;
using HRM.Interview.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.Infrastructure.Service
{
    public class FeedbackServiceAsync : IFeedbackServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IFeedbackRepositoryAsync feedbackRepositoryAsync;
        public FeedbackServiceAsync(IFeedbackRepositoryAsync _feedbackRepositoryAsync)
        {
            feedbackRepositoryAsync = _feedbackRepositoryAsync;
        }

        public async Task<int> AddFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                Rating = model.Rating,
                Comment = model.Comment
            };
            return await feedbackRepositoryAsync.InsertAsync(feedback);
        }

        public async Task<int> DeleteFeedbackAsync(int Id)
        {
            return await feedbackRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbacksAsync()
        {
            var result = await feedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new FeedbackResponseModel
                {
                    Id = model.Id,
                    Rating = model.Rating,
                    Comment = model.Comment

                });
            }
            return null;
        }

        public async Task<FeedbackResponseModel> GetFeedbackByIdAsnc(int Id)
        {
            var model = await feedbackRepositoryAsync.GetByIdAsync(Id);
            if(model !=null)
            { 
                return new FeedbackResponseModel()
                {
                    Id = model.Id,
                    Rating = model.Rating,
                    Comment = model.Comment

                };
            }
            return null;
        }

        public Task<int> UpdateFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                Rating = model.Rating,
                Comment = model.Comment

            };
            return feedbackRepositoryAsync.UpdateAsync(feedback);
        }
    }
}
