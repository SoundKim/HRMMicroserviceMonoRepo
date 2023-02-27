using HRM.Recruiting.ApplicationCore.Contract.Service;
using HRM.Recruiting.ApplicationCore.Model.Request;
using HRM.Recruiting.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Recruiting.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmissionResponseModel model)
        {
            if (ModelState.IsValid)
            {
                await submissionServiceAsync.AddSubmissionAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await submissionServiceAsync.GetAllSubmissionsAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await submissionServiceAsync.GetSubmissionByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This submission doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await submissionServiceAsync.GetSubmissionByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This submission doesn't exist!");
            }

            await submissionServiceAsync.DeleteSubmissionAsync(id);
            return Ok("Deleted");
        }

    }
}
