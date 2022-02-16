using Payroll.BL.Models;
using Payroll.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesByDepartmentID(long departmentID);
        Task<EmployeeDto> GetEmployeeByEmployeeID(long EmployeeID);

        //Command Services
        Task<EmployeeDto> AddNewEmployee(EmployeeDto Employee);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto Employee);
        void DeleteEmployee(EmployeeDto Employee);
        void DeleteEmployeebyEmployeeID(long EmployeeID);
    }
}
