using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DAL.Repositories.CommandRepositories
{
    public class DepartmentCommandRepository : IDepartmentSaveRepository
    {
        private PayrollDBContext payrollDBContext { get; set; }

        public DepartmentCommandRepository(PayrollDBContext dBContext)
        {
            payrollDBContext = dBContext;
        }

        public async Task<Department> AddNewDepartment(Department department)
        {
            await payrollDBContext.Departments.AddAsync(department);
            await payrollDBContext.SaveChangesAsync();
            return department;
        }

        public void DeleteDepartment(Department department)
        {
            payrollDBContext.Departments.Remove(department);
            payrollDBContext.SaveChanges();
        }

        public void DeleteDepartmentByDepartmentID(long departmentID)
        {
            var depertment = payrollDBContext.Departments.Find(departmentID);
            DeleteDepartment(depertment);
        }

        public async Task<Department> UpdateExistingDepartment(Department department)
        {
            var existingDepartment = payrollDBContext.Departments.Attach(department);
            existingDepartment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await payrollDBContext.SaveChangesAsync();
            return department;
        }
    }
}
