﻿using HRM.Authentication.Infrastructure.Contract.Service;
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

        public UserController(IUserServiceAsync _userServiceAsync)
        {
            userServiceAsync = _userServiceAsync;
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

    }
}
