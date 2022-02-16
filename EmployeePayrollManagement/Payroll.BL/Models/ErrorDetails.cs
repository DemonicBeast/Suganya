using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Payroll.BL.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessgae { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
