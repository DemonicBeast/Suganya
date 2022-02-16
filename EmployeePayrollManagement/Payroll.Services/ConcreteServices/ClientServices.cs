using Payroll.BL.Models;
using Payroll.BL.Repositories;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Services.ConcreteServices
{
    public class ClientServices : IClientServices
    {
        private IClientRetrieveRepository ClientQueryContext;
        private IClientSaveRepository ClientCommandContext;

        public ClientServices(IClientRetrieveRepository clientRetrieveRepository,IClientSaveRepository clientSaveRepository)
        {
            ClientQueryContext = clientRetrieveRepository;
            ClientCommandContext = clientSaveRepository;
        }
        
        private Client DtoToEntity(ClientDto clientDto)
        {
            Client client = new Client()
            {
                ClientID = clientDto.ClientID,
                Name = clientDto.Name,
                Description = clientDto.Description,
                PayrollDate = clientDto.PayrollDate
            };
            foreach(long DepartmentID in clientDto.DepartmentIDs)
            {
                if(client.ClientDepartments==null)
                {
                    client.ClientDepartments = new List<ClientDepartment>();
                }
                client.ClientDepartments.Add(new ClientDepartment() { ClientID = clientDto.ClientID, DepartmentID = DepartmentID });
            }
            return client;
        }
        
        
        public async Task<ClientDto> AddNewClient(ClientDto client)
        {
            Client Cl = DtoToEntity(client);
            Cl=await ClientCommandContext.AddNewClient(Cl);
            client.ClientID = Cl.ClientID;
            return client;
        }

        public void DeleteClient(ClientDto client)
        {
            ClientCommandContext.DeleteClient(DtoToEntity(client));
        }

        public void DeleteClientbyClientID(long ClientID)
        {
            ClientCommandContext.DeleteClientByClientID(ClientID);
        }

        public async Task<IEnumerable<ClientDto>> GetAllCleints()
        {
            var clients = await ClientQueryContext.GetAllClients();
            List<ClientDto> clientDtos = new List<ClientDto>();
            foreach(Client cl in clients)
            {
                clientDtos.Add(EntityToDto(cl));
            }
            return clientDtos;
        }

        private ClientDto EntityToDto(Client cl)
        {
            ClientDto clientDto = new ClientDto()
            {
                ClientID = cl.ClientID,
                Name = cl.Name,
                Description = cl.Description,
                PayrollDate = cl.PayrollDate
            };
            if (cl.ClientDepartments != null)
            {
                if(clientDto.DepartmentIDs == null)
                {
                    clientDto.DepartmentIDs = new List<long>();
                }
                foreach (ClientDepartment cld in cl.ClientDepartments)
                {
                    clientDto.DepartmentIDs.Add(cld.DepartmentID);
                }
            }
            return clientDto;
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsByDepartmentID(long departmentID)
        {
            var clients = await ClientQueryContext.GetClientsByDepartmentID(departmentID);
            List<ClientDto> clientDtos = new List<ClientDto>();
            foreach (Client cl in clients)
            {
                clientDtos.Add(EntityToDto(cl));
            }
            return clientDtos;
        }

        public async Task<ClientDto> GetClientByClientID(long ClientID)
        {
            var client = await ClientQueryContext.GetClientByID(ClientID);
            return EntityToDto(client);
        }

        public async Task<ClientDto> UpdateClient(ClientDto client)
        {
            await ClientCommandContext.UpdateClient(DtoToEntity(client));
            return client;
        }
    }
}
