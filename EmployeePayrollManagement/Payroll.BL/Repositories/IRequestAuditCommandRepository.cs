using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IRequestAuditCommandRepository
    {
        Task<AuditRequest> AddNewAudit(AuditRequest audit);
    }
}
