using Payroll.BL.Models;
using Payroll.BL.Repositories;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.ConcreteServices
{
    public class EmployeeService : IEmployeeService,IEntityConversion<EmployeeDto,Employee>
    {
        private IEmployeeCommandRepository empComRep;
        private IEmployeeQueryRepository empQueryRep;

        public EmployeeService(IEmployeeQueryRepository employeeQueryRepository,IEmployeeCommandRepository employeeCommandRepository)
        {
            empComRep = employeeCommandRepository;
            empQueryRep = employeeQueryRepository;
        }

        public Employee DtoToEntity(EmployeeDto dto)
        {
            Employee emp = new Employee()
            {
                EmployeeID = dto.EmployeeID,
                EmployeeCode = dto.EmployeeCode,
                EmployeeName = dto.EmployeeName,
                Address = dto.Address,
                Designation = dto.Designation,
                JoiningDate = dto.JoiningDate,
                Salary = dto.Salary,
                EmployeeDepartments = new List<EmployeeDepartment>()
            };
            foreach(long DepartmentID in dto.DepartmentIDs)
            {
                emp.EmployeeDepartments.Add(new EmployeeDepartment() { Employee = emp, EmployeeID= emp.EmployeeID, DepartmentID = DepartmentID });
            }
            return emp;
        }

        public EmployeeDto EntityToDto(Employee Entity)
        {
            return new EmployeeDto()
            {
                EmployeeID = Entity.EmployeeID,
                EmployeeCode = Entity.EmployeeCode,
                EmployeeName = Entity.EmployeeName,
                Address = Entity.Address,
                Designation = Entity.Designation,
                JoiningDate = Entity.JoiningDate,
                Salary = Entity.Salary,
                DepartmentIDs = Entity.EmployeeDepartments.Select(x=>x.DepartmentID).ToList()
            };
        }

        public async Task<EmployeeDto> AddNewEmployee(EmployeeDto Employee)
        {
            Employee emp = await empComRep.AddNewEmployee(DtoToEntity(Employee));
            Employee.EmployeeID = emp.EmployeeID;
            return Employee;
        }
        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto Employee)
        {
            await empComRep.UpdateExistingEmployee(DtoToEntity(Employee));
            return Employee;
        }

        public void DeleteEmployee(EmployeeDto Employee)
        {
            empComRep.DeleteEmployee(DtoToEntity(Employee));
        }

        public void DeleteEmployeebyEmployeeID(long EmployeeID)
        {
            empComRep.DeleteEmployeeByEmployeeID(EmployeeID);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            IEnumerable<Employee> emps =  await empQueryRep.GetAllEmployees();
            return emps.Select(x => EntityToDto(x)).ToList();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesByDepartmentID(long departmentID)
        {
            IEnumerable<Employee> emp = await empQueryRep.GetEmployeesByDepartmentID(departmentID);
            return emp.Select(x => EntityToDto(x)).ToList();
        }

        public async Task<EmployeeDto> GetEmployeeByEmployeeID(long EmployeeID)
        {
            return  EntityToDto( await empQueryRep.GetEmployeeByEmployeeID(EmployeeID));
        }


    }
}
