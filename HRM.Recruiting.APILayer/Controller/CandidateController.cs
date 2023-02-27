﻿using HRM.Recruiting.ApplicationCore.Contract.Service;
using HRM.Recruiting.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await candidateServiceAsync.GetAllCandidatesAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await candidateServiceAsync.GetCandidateByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This candidate doesn't exist!");
            }

            await candidateServiceAsync.DeleteCandidateAsync(id);
            return Ok("Deleted");
        }

    }
}
