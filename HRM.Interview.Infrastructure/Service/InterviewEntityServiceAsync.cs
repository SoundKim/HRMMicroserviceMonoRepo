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
    public class InterviewEntityServiceAsync : IInterviewEntityServiceAsync
    {
        //Here Add ctor (DI)
        private readonly IInterviewEntityRepositoryAsync interviewEntityRepositoryAsync;
        public InterviewEntityServiceAsync(IInterviewEntityRepositoryAsync _interviewEntityRepositoryAsync)
        {
            interviewEntityRepositoryAsync = _interviewEntityRepositoryAsync;
        }

        public async Task<int> AddInterviewEntityAsync(InterviewEntityRequestModel model)
        {
            InterviewEntity interviewEntity = new InterviewEntity()
            {
                Id = model.Id,
                RecruiterId = model.RecruiterId,
                SubmissionId = model.SubmissionId,
                InterviewTypeId = model.InterviewTypeId,
                InterviewRound = model.InterviewRound,
                ScheduledOn = model.ScheduledOn,
                InterviewerId = model.InterviewerId,
                FeedbackId = model.FeedbackId
            };
            return await interviewEntityRepositoryAsync.InsertAsync(interviewEntity);
        }

        public async Task<int> DeleteInterviewEntityAsync(int Id)
        {
            return await interviewEntityRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<InterviewEntityResponseModel>> GetAllInterviewEntitysAsync()
        {
            var result = await interviewEntityRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new InterviewEntityResponseModel
                {
                    Id = model.Id,
                    RecruiterId = model.RecruiterId,
                    SubmissionId = model.SubmissionId,
                    InterviewTypeId = model.InterviewTypeId,
                    InterviewRound = model.InterviewRound,
                    ScheduledOn = model.ScheduledOn,
                    InterviewerId = model.InterviewerId,
                    FeedbackId = model.FeedbackId
                });
            }
            return null;
        }

        public async Task<InterviewEntityResponseModel> GetInterviewEntityByIdAsnc(int Id)
        {
            var model = await interviewEntityRepositoryAsync.GetByIdAsync(Id);
            if(model !=null)
            { 
                return new InterviewEntityResponseModel()
                {
                    Id = model.Id,
                    RecruiterId = model.RecruiterId,
                    SubmissionId = model.SubmissionId,
                    InterviewTypeId = model.InterviewTypeId,
                    InterviewRound = model.InterviewRound,
                    ScheduledOn = model.ScheduledOn,
                    InterviewerId = model.InterviewerId,
                    FeedbackId = model.FeedbackId
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewEntityAsync(InterviewEntityRequestModel model)
        {
            InterviewEntity interviewEntity = new InterviewEntity()
            {
                Id = model.Id,
                RecruiterId = model.RecruiterId,
                SubmissionId = model.SubmissionId,
                InterviewTypeId = model.InterviewTypeId,
                InterviewRound = model.InterviewRound,
                ScheduledOn = model.ScheduledOn,
                InterviewerId = model.InterviewerId,
                FeedbackId = model.FeedbackId
            };
            return interviewEntityRepositoryAsync.UpdateAsync(interviewEntity);
        }
    }
}
