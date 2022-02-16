using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IEmployeeQueryRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentID(long DepartmentID);

        Task<Employee> GetEmployeeByEmployeeID(long employeeID);
    }
}
