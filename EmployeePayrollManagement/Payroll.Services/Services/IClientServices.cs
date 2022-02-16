using Payroll.BL.Models;
using Payroll.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.Services
{
    public interface IClientServices
    {
        //Query Services
        Task<IEnumerable<ClientDto>> GetAllCleints();
        Task<IEnumerable<ClientDto>> GetAllClientsByDepartmentID(long departmentID);
        Task<ClientDto> GetClientByClientID(long ClientID);

        //Command Services
        Task<ClientDto> AddNewClient(ClientDto client);
        Task<ClientDto> UpdateClient(ClientDto client);
        void DeleteClient(ClientDto client);
        void DeleteClientbyClientID(long ClientID);
    }
}
