using Microsoft.EntityFrameworkCore;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Payroll.DAL.Repositories.QueryRepositories
{
    public class ClientQueryRepository : IClientRetrieveRepository
    {
        private PayrollDBContext PayrollDBContext { get; set; }
        public ClientQueryRepository(PayrollDBContext dBContext)
        {
            PayrollDBContext = dBContext;
        }
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await PayrollDBContext.Clients.Include(c => c.ClientDepartments).ThenInclude(x=>x.Department).ToListAsync();
        }

        public async Task<Client> GetClientByID(long ClientID)
        {
            return await PayrollDBContext.Clients.Include(c => c.ClientDepartments).ThenInclude(c=>c.Department).Where(x => x.ClientID == ClientID).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetClientsByDepartmentID(long DepartmentID)
        {
            var Clients = await PayrollDBContext.ClientDepartments.Include(x => x.Client).ThenInclude(x=>x.ClientDepartments).
                Where(x => x.DepartmentID == DepartmentID).Select(x=>x.Client)
                .ToListAsync();
            return Clients;
        }
    }
}
