using HRM.Recruiting.ApplicationCore.Contract.Repository;
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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepositoryAsync submissionRepositoryAsync;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionRepositoryAsync)
        {
            submissionRepositoryAsync = _submissionRepositoryAsync;
        }

        public async Task<int> AddSubmissionAsync(SubmissionResponseModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn = model.RejectedOn,
                SubmissionStatusId = model.SubmissionStatusId
            };
            return await submissionRepositoryAsync.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int Id)
        {
            return await submissionRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync()
        {
            var result = await submissionRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new SubmissionResponseModel
                {
                    Id = model.Id,
                    CandidateId = model.CandidateId,
                    JobRequirementId = model.JobRequirementId,
                    SubmittedOn = model.SubmittedOn,
                    ConfirmedOn = model.ConfirmedOn,
                    RejectedOn = model.RejectedOn,
                    SubmissionStatusId = model.SubmissionStatusId
                });
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsnc(int Id)
        {
            var model = await submissionRepositoryAsync.GetByIdAsync(Id);
            if (model != null)
            {
                return new SubmissionResponseModel()
                {
                    Id = model.Id,
                    CandidateId = model.CandidateId,
                    JobRequirementId = model.JobRequirementId,
                    SubmittedOn = model.SubmittedOn,
                    ConfirmedOn = model.ConfirmedOn,
                    RejectedOn = model.RejectedOn,
                    SubmissionStatusId = model.SubmissionStatusId


                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionResponseModel model)
        {
            Submission submission = new Submission()
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                SubmittedOn = model.SubmittedOn,
                ConfirmedOn = model.ConfirmedOn,
                RejectedOn = model.RejectedOn,
                SubmissionStatusId = model.SubmissionStatusId


            };
            return submissionRepositoryAsync.UpdateAsync(submission);
        }
    }
}
