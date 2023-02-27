﻿using HRM.Authentication.Infrastructure.Contract.Service;
using HRM.Authentication.Infrastructure.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Authentication.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServiceAsync roleServiceAsync;

        public RoleController(IRoleServiceAsync _roleServiceAsync)
        {
            roleServiceAsync = _roleServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await roleServiceAsync.AddRoleAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await roleServiceAsync.GetAllRolesAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await roleServiceAsync.GetRoleByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This role doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await roleServiceAsync.GetRoleByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This role doesn't exist!");
            }

            await roleServiceAsync.DeleteRoleAsync(id);
            return Ok("Deleted");
        }

    }
}
