using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myrtex.DAL.DtoS;
using myrtex.DAL.Interfaces;

namespace myrtex.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employee;

        public EmployeeController(IEmployeeRepo employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var response = await _employee.GetEmployeesAsync();

            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var response = await _employee.GetEmployeeAsync(id);

            if (response != null)
                return Ok(response);
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeDto model)
        {
            var response = await _employee.CreateEmployeeAsync(model);

            if (response)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateEmployeeDto model)
        {
            var response = await _employee.EditEmployeeAsync(id, model);
            
            if (response)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var response = await _employee.DeleteEmployeeAsync(id);
            
            if (response)
                return Ok();
            return BadRequest();
        }
    }
}