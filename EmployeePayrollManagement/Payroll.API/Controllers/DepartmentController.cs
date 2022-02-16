using Microsoft.AspNetCore.Mvc;
using Payroll.API.ExceptionHandling;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Controllers
{
    [Route("api/Department")]
    [ApiController]
    [AttribException]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService departmentService;
        
        public DepartmentController(IDepartmentService service)
        {
            departmentService = service;
        }
        //[Route("AllDepartments")]
        [HttpGet("GetAllDepartments")]
        public async Task <ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartments()
        {
            var departments = await departmentService.GetAllDepartments();
            return Ok(departments);
        }
        [HttpGet("GetDepartmentByID")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentByID(long id)
        {
            var department = await departmentService.GetDepartmentByDepartmentID(id);
            return Ok(department);
        }
        [HttpPost("AddNewDepartment")]
        public async Task<ActionResult<DepartmentDto>>AddNewDepartment(DepartmentDto department)
        {
            var Department =await departmentService.AddNewDepartment(department);
            return Ok(Department);
        }
        [HttpPut("UpdateExistingDepartment")]
        public async Task<ActionResult<DepartmentDto>>UpdateDepartment(DepartmentDto department)
        {
            var Department = await departmentService.UpdateDepartment(department);
            return Ok(Department);
        }
        [HttpDelete("DeleteDepartment")]
        public  bool DeleteDepartment(DepartmentDto department)
        {
            departmentService.DeleteDepartment(department);
            return true;
        }
        [HttpDelete("DeleteDepartmentByDepartmentID")]
        public bool DeleteDepartmentbyDepartmentID(long departmentID)
        {
            departmentService.DeleteDepartmentByDepartmentID(departmentID);
            return true;
        }

    }
}
