using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMgt.API.Models;
using EmployeeMgt.API.Repository;

namespace EmployeeMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var Employee = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(Employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            var Employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if(Employee==null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        [HttpGet("dept/{id}")]
        public async Task<IActionResult> GetAllEmployeeByDeptID([FromRoute] int id)
        {
            var Employee = await _employeeRepository.GetAllEmployeeByDeptIdAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeModels employeeModels)
        {
            var Employee = await _employeeRepository.AddNewEmployeeAsync(employeeModels);
            return Ok(Employee);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateEmployee([FromRoute] int id,[FromBody] EmployeeModels employeeModels)
        {
            var Employee = await _employeeRepository.UpdateEmployeeByIdAsync(id,employeeModels);

            if(Employee==0)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployeeByEmpId([FromRoute] int id)
        {
            var Employee = await _employeeRepository.DeleteEmployeeByIdAsync(id);

            if (Employee == 0)
            {
                return false;
            }
            return true;
        }

        [HttpDelete("dept/{id}")]
        public async Task<bool> DeleteEmployeeByDeptID([FromRoute] int id)
        {
            var Employee = await _employeeRepository.DeleteEmployeeByDeptIdAsync(id);

            if (Employee == 0)
            {
                return false;
            }
            return true;
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> DeleteEmployeeByDeptID([FromRoute] string name)
        {
            var Employee = await _employeeRepository.GetAllEmployeeByNameAsync(name);

            if(Employee==null)
            {
                NotFound();
            }
            return Ok(Employee);
        }

    }
}
