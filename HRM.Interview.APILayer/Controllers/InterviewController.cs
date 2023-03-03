using HRM.Interview.APILayer.Model;
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
        private readonly IConfiguration config;
        private readonly HttpClient httpClient = new HttpClient();
      

        //private readonly ConfigurationBuilder config = new 

        public InterviewController(IInterviewEntityServiceAsync _interviewEntityServiceAsync, IConfiguration _config)
        {
            interviewEntityServiceAsync = _interviewEntityServiceAsync;
            config = _config;
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

        //synchronous network
        [HttpGet("Candidate")]
        public async Task<IActionResult> GetCandidate()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("RecruitingApiURL").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<CandidateModel>>(httpClient.BaseAddress + "Candidate");
            return Ok(result);
        }

        //synchronous network
        [HttpGet("Submission")]
        public async Task<IActionResult> GetSubmission()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("RecruitingApiURL").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<SubmissionModel>>(httpClient.BaseAddress + "Submission");
            return Ok(result);
        }


        [HttpGet("Employee")]
        public async Task<IActionResult> GetEmployee()
        {
            httpClient.BaseAddress = new Uri(config.GetSection("OnboardApiURL").Value);
            var result = await httpClient.GetFromJsonAsync<IEnumerable<EmployeeModel>>(httpClient.BaseAddress + "Employee");
            return Ok(result);
        }


    }
}
