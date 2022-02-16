using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Services.Dto
{
    public class EmployeeDto
    {
        /// <summary>
        /// Identity value for Employee data
        /// </summary>
        public long EmployeeID { get; set; }
        /// <summary>
        /// Name of the employee
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Unique code for each employee
        /// </summary>
        public string EmployeeCode { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
        public List<long> DepartmentIDs { get; set; }
    }
}
