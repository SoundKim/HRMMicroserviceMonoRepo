﻿using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;

        public InterviewTypeController(IInterviewTypeServiceAsync _interviewTypeServiceAsync)
        {
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewTypeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewTypeServiceAsync.AddInterviewTypeAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewTypeServiceAsync.GetAllInterviewTypesAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This interview type doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await interviewTypeServiceAsync.GetInterviewTypeByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This interview type doesn't exist!");
            }

            await interviewTypeServiceAsync.DeleteInterviewTypeAsync(id);
            return Ok("Deleted");
        }

    }
}
