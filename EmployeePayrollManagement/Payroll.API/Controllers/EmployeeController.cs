using Microsoft.AspNetCore.Mvc;
using Payroll.API.ExceptionHandling;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [AttribException]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService empService)
        {
            employeeService = empService;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployee()
        {
            return await employeeService.GetAllEmployees();
        }
        [HttpGet("GetAllEmployeesByDepartmentID")]
        public async Task<IEnumerable<EmployeeDto>>GetEmployeesByDepartmentID(long departmentID)
        {
            return await employeeService.GetAllEmployeesByDepartmentID(departmentID);
        }
        [HttpGet("GetEmployeeByEmployeeID")]
        public async Task<EmployeeDto> GetEmployeeByEmployeeID(long employeeID)
        {
            return await employeeService.GetEmployeeByEmployeeID(employeeID);
        }
        [HttpPost("AddNewEmployee")]
        public async Task<ActionResult<EmployeeDto>>AddNewEmployee(EmployeeDto employee)
        {
            var emp = await employeeService.AddNewEmployee(employee);
            return Ok(emp);
        }
        [HttpPut("EditEmployee")]
        public async Task<ActionResult<EmployeeDto>>UpdateExistingEmployee(EmployeeDto employee)
        {
            var emp = await employeeService.UpdateEmployee(employee);
            return Ok(emp);
        }
        [HttpDelete("DeleteEmployee")]
        public ActionResult DeleteEmployee(EmployeeDto employee)
        {
            employeeService.DeleteEmployee(employee);
            return Ok("Deleted Successfully");
        }
        [HttpDelete("DeleteEmployeeByEmployeeID")]
        public ActionResult DeleteEmployeeByEmployeeID(long EmployeeID)
        {
            employeeService.DeleteEmployeebyEmployeeID(EmployeeID);
            return Ok("Deleted Successfully");
        }
    }
}
