using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Payroll.DAL.Repositories.QueryRepositories
{
    public class DepartmentQueryRepository : IDepartmentRetriveRepository
    {
        private PayrollDBContext payrollDBContext { get; set; }
        public DepartmentQueryRepository(PayrollDBContext dBContext)
        {
            payrollDBContext = dBContext;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await payrollDBContext.Departments.ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsByClientID(long ClientID)
        {
            var Departments = await payrollDBContext.Departments.Include(m => m.ClientDepartments).ToListAsync();
            return Departments;
            
        }

        public async Task<Department> GetDepartmentByID(long DepartmentID)
        {
            return await payrollDBContext.Departments.Include(m => m.ClientDepartments).Include(d => d.EmployeeDepartments).Where(x => x.DepartmentID == DepartmentID).SingleOrDefaultAsync();
        }
    }
}
