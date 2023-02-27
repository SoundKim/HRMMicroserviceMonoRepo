using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync interviewerServiceAsync;

        public InterviewerController(IInterviewerServiceAsync _interviewerServiceAsync)
        {
            interviewerServiceAsync = _interviewerServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(InterviewerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewerServiceAsync.AddInterviewerAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await interviewerServiceAsync.GetAllInterviewersAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await interviewerServiceAsync.GetInterviewerByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This interviewer doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await interviewerServiceAsync.GetInterviewerByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This interviewer doesn't exist!");
            }

            await interviewerServiceAsync.DeleteInterviewerAsync(id);
            return Ok("Deleted");
        }

    }
}
