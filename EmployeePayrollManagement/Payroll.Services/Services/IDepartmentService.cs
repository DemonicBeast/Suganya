using Payroll.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Services
{
    public interface IDepartmentService
    {
        //Query 
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentByDepartmentID(long DepartmentID);

        //Command
        Task<DepartmentDto> AddNewDepartment(DepartmentDto department);
        Task<DepartmentDto> UpdateDepartment(DepartmentDto department);
        void DeleteDepartment(DepartmentDto department);
        void DeleteDepartmentByDepartmentID(long departmentID);
    }
}
