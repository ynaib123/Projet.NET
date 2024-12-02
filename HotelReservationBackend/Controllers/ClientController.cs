using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient(Client client)
        {
            await _clientService.CreateClientAsync(client);
            return CreatedAtAction(nameof(GetAllClients), new { id = client.Id }, client);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            await _clientService.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
