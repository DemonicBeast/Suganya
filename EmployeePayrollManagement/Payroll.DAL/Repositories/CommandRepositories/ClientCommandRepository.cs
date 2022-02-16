using Microsoft.EntityFrameworkCore;
using Payroll.BL.Models;
using Payroll.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DAL.Repositories.CommandRepositories
{
    public class ClientCommandRepository : IClientSaveRepository
    {
        public PayrollDBContext payrollDBContext { get; set; }
        public ClientCommandRepository(PayrollDBContext dBContext)
        {
            payrollDBContext = dBContext;
        }
        public async Task<Client> AddNewClient(Client NewClient)
        {
            foreach(ClientDepartment clientDepartment in NewClient.ClientDepartments)
            {
                clientDepartment.Client = NewClient;
                clientDepartment.Department = payrollDBContext.Departments.Find(clientDepartment.DepartmentID);
            }

            await payrollDBContext.Clients.AddAsync(NewClient);
            await payrollDBContext.SaveChangesAsync();
            return NewClient;
        }

        public  bool  DeleteClient(Client delClient)
        {
            try
            {
                payrollDBContext.Clients.Remove(delClient);
                payrollDBContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public bool DeleteClientByClientID(long ClientID)
        {
            Client client = payrollDBContext.Clients.Find(ClientID);
            if (client != null)
            {
                return this.DeleteClient(client);

            }
            else
                return false;
        }

        public async Task<Client> UpdateClient(Client ExistingClient)
        {
            try
            {
                //Object From Db
                Client client = payrollDBContext.Clients.Include(x => x.ClientDepartments).
                    ThenInclude(x => x.Department).FirstOrDefault(x => x.ClientID == ExistingClient.ClientID);
                //Updating new value
                client.Name = ExistingClient.Name;
                client.Description = ExistingClient.Description;
                client.PayrollDate = ExistingClient.PayrollDate;
                List<ClientDepartment> ToRemove = new List<ClientDepartment>();
                List<ClientDepartment> ToAdd = new List<ClientDepartment>();

                //Updating Relationship Tables
              

                //Deleting Unselected Departments
                foreach(ClientDepartment clientDepartment1 in client.ClientDepartments)
                {
                    if(!ExistingClient.ClientDepartments.Any(x=>x.DepartmentID == clientDepartment1.DepartmentID))
                    {
                        ToRemove.Add(clientDepartment1);
                    }
                }
                payrollDBContext.RemoveRange(ToRemove);
                //Adding New Department 
                foreach (ClientDepartment clientDepartment in ExistingClient.ClientDepartments)
                {
                    if (!client.ClientDepartments.Any(x => x.DepartmentID == clientDepartment.DepartmentID))
                    {
                        clientDepartment.Client = client;
                        clientDepartment.Department = payrollDBContext.Departments.Find(clientDepartment.DepartmentID);
                        client.ClientDepartments.Add(clientDepartment);
                    }
                }

                await payrollDBContext.SaveChangesAsync();
                return client;
            }
            catch
            {
                throw;
            }
        }
    }
}
