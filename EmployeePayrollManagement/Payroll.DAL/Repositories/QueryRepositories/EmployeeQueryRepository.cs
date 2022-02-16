using Microsoft.EntityFrameworkCore;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DAL.Repositories.QueryRepositories
{
    public class EmployeeQueryRepository : IEmployeeQueryRepository
    {
        private PayrollDBContext PayrollDBContext { get; set; }
        public EmployeeQueryRepository(PayrollDBContext dBContext)
        {
            PayrollDBContext = dBContext;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await PayrollDBContext.Employees.Include(x => x.EmployeeDepartments).ThenInclude(x=>x.Department).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByEmployeeID(long employeeID)
        {
            return await PayrollDBContext.Employees.Include(m => m.EmployeeDepartments).ThenInclude(x=>x.Department).Where(x => x.EmployeeID == employeeID).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentID(long DepartmentID)
        {
            var Employees = await PayrollDBContext.EmployeeDepartments.Include(c => c.Employee).ThenInclude(X => X.EmployeeDepartments).Where(x => x.DepartmentID == DepartmentID).Select(x => x.Employee).ToListAsync();
            return Employees;
        }
    }
}
