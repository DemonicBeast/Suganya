using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IClientRetrieveRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientByID(long ClientID);
        Task<IEnumerable<Client>> GetClientsByDepartmentID(long DepartmentID);
    }
}
