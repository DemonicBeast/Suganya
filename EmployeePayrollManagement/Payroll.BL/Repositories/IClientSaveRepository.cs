using Payroll.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.BL.Repositories
{
    public interface IClientSaveRepository
    {
        Task<Client> AddNewClient(Client NewClient);
        Task<Client> UpdateClient(Client ExistingClient);

       bool DeleteClient(Client delClient);
       bool DeleteClientByClientID(long ClientID);
    }
}
