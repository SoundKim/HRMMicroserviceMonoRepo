﻿using HRM.Recruiting.ApplicationCore.Contract.Service;
using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequirementController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobRequirementResponseModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await jobRequirementServiceAsync.GetAllJobRequirementsAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This job requirement doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This job requirement doesn't exist!");
            }

            await jobRequirementServiceAsync.DeleteJobRequirementAsync(id);
            return Ok("Deleted");
        }

    }
}
