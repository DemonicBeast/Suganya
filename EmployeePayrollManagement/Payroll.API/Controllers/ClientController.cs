using Microsoft.AspNetCore.Mvc;
using Payroll.API.ExceptionHandling;
using Payroll.Services.Dto;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API.Controllers
{
    [Route("api/Client")]
    [ApiController]
    [AttribException]
    public class ClientController : ControllerBase
    {
        private IClientServices clientContextService;
        public ClientController(IClientServices clientServices)
        {
            clientContextService = clientServices;
        }
        [HttpGet("GetAllClients")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var clients = await clientContextService.GetAllCleints();
            return Ok(clients);
        }
        [HttpGet("GetAllClientsByDepartmentID")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClientsByDepartmentID(long DepartmentID)
        {
            var clients = await clientContextService.GetAllClientsByDepartmentID(DepartmentID);
            return Ok(clients);
        }
        [HttpGet("GetClientByClientID")]
        public async Task<ActionResult<ClientDto>> GetClientByClientID(long ClientID)
        {
            var client = await clientContextService.GetClientByClientID(ClientID);
            return Ok(client);
        }
        [HttpPost("AddNewClient")]
        public async Task<ActionResult<ClientDto>>AddNewClient(ClientDto clientDto)
        {
            var client = await clientContextService.AddNewClient(clientDto);
            return Ok(client);
        }
        [HttpPut("EditClient")]
        public async Task<ActionResult<ClientDto>> UpdateExistingClient(ClientDto existingClient)
        {
            var client = await clientContextService.UpdateClient(existingClient);
            return Ok(client);
        }
        [HttpDelete("DeleteClient")]
        public ActionResult DeleteClient(ClientDto client)
        {
            clientContextService.DeleteClient(client);
            return Ok();
        }
        [HttpDelete("DeleteClientByClientID")]
        public ActionResult DeleteClientbyClientID(long clientID)
        {
            clientContextService.DeleteClientbyClientID(clientID);
            return Ok();
        }
    }
}
