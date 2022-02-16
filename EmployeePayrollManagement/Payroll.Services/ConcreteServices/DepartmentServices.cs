using Payroll.BL.Models;
using Payroll.BL.Repositories;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.ConcreteServices
{
    public class DepartmentServices : IDepartmentService
    {
        private IDepartmentRetriveRepository DepartmentRetrive;
        private IDepartmentSaveRepository DepartmentSave;

        public DepartmentServices(IDepartmentRetriveRepository departmentRetriveRepository,IDepartmentSaveRepository departmentSaveRepository)
        {
            DepartmentRetrive = departmentRetriveRepository;
            DepartmentSave = departmentSaveRepository;
        }
        public async Task<DepartmentDto> AddNewDepartment(DepartmentDto department)
        {
            Department dep = DtoToEntity(department);
            dep = await DepartmentSave.AddNewDepartment(dep);
            department.DepartmentID = dep.DepartmentID;
            return department;
        }

        private Department DtoToEntity(DepartmentDto department)
        {
            return new Department()
            {
                DepartmentID = department.DepartmentID,
                Name = department.Name,
                Description = department.Description
            };
        }

        public void DeleteDepartment(DepartmentDto department)
        {
            Department dep = DtoToEntity(department);
            DepartmentSave.DeleteDepartment(dep);
        }

        public void DeleteDepartmentByDepartmentID(long departmentID)
        {
            DepartmentSave.DeleteDepartmentByDepartmentID(departmentID);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            var departments = await DepartmentRetrive.GetAllDepartments();
            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();
            foreach(Department dep in departments)
            {
                DepartmentDto department = new DepartmentDto()
                {
                    DepartmentID = dep.DepartmentID,
                    Name = dep.Name,
                    Description = dep.Description
                };
                departmentDtos.Add(department);
            }
            return departmentDtos;
        }

        public async Task<DepartmentDto> GetDepartmentByDepartmentID(long DepartmentID)
        {
            var dep = await DepartmentRetrive.GetDepartmentByID(DepartmentID);
            return new DepartmentDto()
            {
                DepartmentID = dep.DepartmentID,
                Name = dep.Name,
                Description = dep.Description
            };
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto department)
        {
            Department dep = DtoToEntity(department);
            await DepartmentSave.UpdateExistingDepartment(dep);
            return department;
        }
    }
}
