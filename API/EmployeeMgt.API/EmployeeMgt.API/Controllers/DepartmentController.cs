using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeMgt.API.Repository;
using EmployeeMgt.API.Models;

namespace EmployeeMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllDepartmnet()
        {
            var departments = await _departmentRepository.GetAllDepartmentAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmnetById([FromRoute]int id)
        {
            var departments = await _departmentRepository.GetDepartmentByIdAsync(id);

            if(departments==null)
            {
               return NotFound();
            }

            return Ok(departments);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDepartmnets([FromBody] DepartmentModels departmentModels)
        {
            var DeptID = await _departmentRepository.AddNewDepartmentAsync(departmentModels);
            return Ok(DeptID);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmnets(int id,[FromBody] DepartmentModels departmentModels)
        {
            int DeptID = await _departmentRepository.UpdateDepartmentAsync(id, departmentModels);
            if(DeptID==0)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmnets(int id)
        {
            int DeptID = await _departmentRepository.DeleteDepartmentAsync(id);
            if (DeptID == 0)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetDepartmnetByName([FromRoute] string name)
        {
            var departments = await _departmentRepository.GetAllDepartmentByNameAsync(name);

            if (departments == null)
            {
                return NotFound();
            }

            return Ok(departments);
        }
    }
}
