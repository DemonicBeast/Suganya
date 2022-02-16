using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BL.Models
{
    public class EmployeeDepartment
    {
        public long EmployeeDepartmentID { get; set; }
        public long EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public long DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
