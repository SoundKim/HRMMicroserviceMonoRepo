using HRM.Interview.ApplicationCore.Contract.Service;
using HRM.Interview.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Interview.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync recruiterServiceAsync;

        public RecruiterController(IRecruiterServiceAsync _recruiterServiceAsync)
        {
            recruiterServiceAsync = _recruiterServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecruiterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await recruiterServiceAsync.AddRecruiterAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await recruiterServiceAsync.GetAllRecruitersAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await recruiterServiceAsync.GetRecruiterByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This recruiter doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0) return BadRequest("Invalid Id");
            var result = await recruiterServiceAsync.GetRecruiterByIdAsnc(id);
            if(result == null)
            {
                return BadRequest("This recruiter doesn't exist!");
            }

            await recruiterServiceAsync.DeleteRecruiterAsync(id);
            return Ok("Deleted");
        }

    }
}
