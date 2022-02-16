using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BL.Models
{
    public class ClientDepartment
    {
        public long ClientDepartmentID { get; set; }
        public long ClientID { get; set; }
        public long DepartmentID { get; set; }
        public Client Client { get; set; }
        public Department Department { get; set; }
    }
}
