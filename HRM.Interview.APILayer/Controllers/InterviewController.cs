using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewEntityServiceAsync interviewEntityServiceAsync;

        public InterviewController(IInterviewEntityServiceAsync _interviewEntityServiceAsync)
        {
            interviewEntityServiceAsync = _interviewEntityServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewEntityRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewEntityServiceAsync.AddInterviewEntityAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewEntityServiceAsync.GetAllInterviewEntitysAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewEntityServiceAsync.GetInterviewEntityByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This interview doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await interviewEntityServiceAsync.GetInterviewEntityByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This interview doesn't exist!");
            }

            await interviewEntityServiceAsync.DeleteInterviewEntityAsync(id);
            return Ok("Deleted");
        }

    }
}
