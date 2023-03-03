using HRM.Authentication.APILayer.Model;
using HRM.Authentication.Infrastructure.Contract.Service;
using HRM.Authentication.Infrastructure.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Authentication.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceAsync userServiceAsync;
        private readonly IConfiguration config;
        private readonly HttpClient httpClient = new HttpClient();

        public UserController(IUserServiceAsync _userServiceAsync, IConfiguration _config)
        {
            userServiceAsync = _userServiceAsync;
            config = _config;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userServiceAsync.AddUserAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await userServiceAsync.GetAllUsersAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This user doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await userServiceAsync.GetUserByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This user doesn't exist!");
            }

            await userServiceAsync.DeleteUserAsync(id);
            return Ok("Deleted");
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
