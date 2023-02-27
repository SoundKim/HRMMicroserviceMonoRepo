using HRM.Onboard.ApplicationCore.Contract.Service;
using HRM.Onboard.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Onboard.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmployeeCategoryServiceAsync employeeCategoryServiceAsync;

        public EmployeeCategoryController(IEmployeeCategoryServiceAsync _employeeCategoryServiceAsync)
        {
            employeeCategoryServiceAsync = _employeeCategoryServiceAsync;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeCategoryServiceAsync.AddEmployeeCategoryAsync(model);
                return Ok(model);
            }
            return BadRequest(model);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await employeeCategoryServiceAsync.GetAllEmployeeCategorysAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await employeeCategoryServiceAsync.GetEmployeeCategoryByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This employee category doesn't exist!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Id");
            var result = await employeeCategoryServiceAsync.GetEmployeeCategoryByIdAsnc(id);
            if (result == null)
            {
                return BadRequest("This employee category doesn't exist!");
            }

            await employeeCategoryServiceAsync.DeleteEmployeeCategoryAsync(id);
            return Ok("Deleted");
        }

    }
}
