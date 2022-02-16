using Microsoft.EntityFrameworkCore;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DAL.Repositories.CommandRepositories
{
    public class EmployeeCommandRepository : IEmployeeCommandRepository
    {
        private PayrollDBContext payrollDBContext { get; set; }
        public EmployeeCommandRepository(PayrollDBContext dBContext)
        {
            payrollDBContext = dBContext;
        }
        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            foreach(EmployeeDepartment emp in employee.EmployeeDepartments)
            {
                emp.Department = payrollDBContext.Departments.Find(emp.DepartmentID);
            }
            await payrollDBContext.Employees.AddAsync(employee);
            await payrollDBContext.SaveChangesAsync();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            payrollDBContext.Remove(employee);
            payrollDBContext.SaveChanges();
        }

        public void DeleteEmployeeByEmployeeID(long employeeID)
        {
            var employee = payrollDBContext.Employees.Find(employeeID);
            if(employee!=null)
            {
                DeleteEmployee(employee);
            }
        }

        public async Task<Employee> UpdateExistingEmployee(Employee employee)
        {
            Employee emp = await payrollDBContext.Employees.Include(x => x.EmployeeDepartments).
                ThenInclude(x => x.Department).FirstOrDefaultAsync(C => C.EmployeeID == employee.EmployeeID);
            emp.EmployeeCode = employee.EmployeeCode;
            emp.EmployeeName = employee.EmployeeName;
            emp.Designation = employee.Designation;
            emp.Address = employee.Address;
            emp.JoiningDate = employee.JoiningDate;
            emp.Salary = employee.Salary;

            List<EmployeeDepartment> ToRemove = new List<EmployeeDepartment>();

            foreach (EmployeeDepartment dep in emp.EmployeeDepartments)
            {
                if (!employee.EmployeeDepartments.Any(x => x.DepartmentID == dep.DepartmentID))
                {
                    ToRemove.Add(dep);
                }
            }
            foreach (EmployeeDepartment dep in employee.EmployeeDepartments)
            {
                if (!emp.EmployeeDepartments.Any(x => x.DepartmentID == dep.DepartmentID))
                {
                    dep.Department = payrollDBContext.Departments.Find(dep.DepartmentID);
                    emp.EmployeeDepartments.Add(dep);
                }
            }
            payrollDBContext.RemoveRange(ToRemove);
            await payrollDBContext.SaveChangesAsync();
            return emp;
        }
    }
}
