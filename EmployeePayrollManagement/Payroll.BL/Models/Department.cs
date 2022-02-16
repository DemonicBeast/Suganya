using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BL.Models
{
    public class Department
    {
        public long DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ClientDepartment> ClientDepartments { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
