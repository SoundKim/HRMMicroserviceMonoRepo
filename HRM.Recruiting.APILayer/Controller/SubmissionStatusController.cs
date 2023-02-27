using HRM.Recruiting.ApplicationCore.Contract.Service;
using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusServiceAsync submissionStatusServiceAsync;

        public SubmissionStatusController(ISubmissionStatusServiceAsync _submissionStatusServiceAsync)
        {
            submissionStatusServiceAsync = _submissionStatusServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionStatusResponseModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionStatusServiceAsync.AddSubmissionStatusAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissionStatusServiceAsync.GetAllSubmissionStatussAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await submissionStatusServiceAsync.GetSubmissionStatusByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This submission status doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await submissionStatusServiceAsync.GetSubmissionStatusByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This submission status doesn't exist!");
            }

            await submissionStatusServiceAsync.DeleteSubmissionStatusAsync(id);
            return Ok("Deleted");
        }

    }
}
