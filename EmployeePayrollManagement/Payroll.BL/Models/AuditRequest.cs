using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.BL.Models
{
    public class AuditRequest
    {
        public long AuditRequestID { get; set; }
        public string RequestedURL { get; set; }
        public string RequestedController { get; set; }
        public string RequestedActionMethod { get; set; }
        public DateTime RequestedDateTime { get; set; }
    }
}
