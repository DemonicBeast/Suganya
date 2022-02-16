using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IDepartmentSaveRepository
    {
        Task<Department> AddNewDepartment(Department department);
        Task<Department> UpdateExistingDepartment(Department department);

        void DeleteDepartment(Department department);
        void DeleteDepartmentByDepartmentID(long departmentID);
    }
}
