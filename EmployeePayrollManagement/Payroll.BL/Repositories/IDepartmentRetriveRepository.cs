using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IDepartmentRetriveRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentByID(long DepartmentID);
        Task<IEnumerable<Department>> GetAllDepartmentsByClientID(long ClientID);
    }
}
