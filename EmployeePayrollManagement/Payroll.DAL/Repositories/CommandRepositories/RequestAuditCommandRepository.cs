using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DAL.Repositories.CommandRepositories
{
    public class RequestAuditCommandRepository : IRequestAuditCommandRepository
    {
        public PayrollDBContext payrollDBContext = null;

        public RequestAuditCommandRepository(PayrollDBContext payrollDB)
        {
            payrollDBContext = payrollDB;
        }
        public async Task<AuditRequest> AddNewAudit(AuditRequest audit)
        {
            var Audit =await payrollDBContext.AuditRequests.AddAsync(audit);
            await payrollDBContext.SaveChangesAsync();
            return audit;
        }
    }
}
