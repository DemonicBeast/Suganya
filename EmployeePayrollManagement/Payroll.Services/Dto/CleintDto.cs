using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Services.Dto
{
    public class ClientDto
    {
        public long ClientID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PayrollDate { get; set; }
        public List<long> DepartmentIDs { get; set; }
    }
}
