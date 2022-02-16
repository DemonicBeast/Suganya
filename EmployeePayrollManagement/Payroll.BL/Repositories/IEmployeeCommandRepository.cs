using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IEmployeeCommandRepository
    {
        Task<Employee> AddNewEmployee(Employee employee);
        Task<Employee> UpdateExistingEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void DeleteEmployeeByEmployeeID(long employeeID);
    }
}
