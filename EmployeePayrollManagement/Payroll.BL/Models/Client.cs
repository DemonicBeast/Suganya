using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BL.Models
{
    public class Client
    {
        public long ClientID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PayrollDate { get; set; }

        public ICollection<ClientDepartment> ClientDepartments { get; set; }
    }
}
