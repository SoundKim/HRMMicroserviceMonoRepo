﻿using HRM.Recruiting.ApplicationCore.Contract.Repository;
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
    public class CandidateServiceAsync : ICandidateServiceAsync
    {
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
        {
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }
        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Mobile = model.Mobile,
                ResumeUrl = model.ResumeUrl
            };
            return await candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int Id)
        {
            return candidateRepositoryAsync.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailId = x.EmailId,
                    Mobile = x.Mobile,
                    ResumeUrl = x.ResumeUrl
                });
            }

            return null;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsnc(int Id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(Id);
            if (result != null)
            {
                return new CandidateResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailId = result.EmailId,
                    Mobile = result.Mobile,
                    ResumeUrl = result.ResumeUrl
                };
            }
            return null;
        }

        public Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                EmailId = model.EmailId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                ResumeUrl = model.ResumeUrl
            };
            return candidateRepositoryAsync.UpdateAsync(candidate);
        }
    }
}
