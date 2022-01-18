using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleOrderService.Model;
using SampleOrderService.Services;

namespace SampleOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : BaseController<IClientService>
    {

        public ClientsController(IClientService service) : base(service)
        {
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var result = await Service.GetClientsAsync();
            return Ok(result);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var result = await Service.GetClientAsync(id);
            return Ok(result);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            var result = await Service.ChangeClientAsync(client);
            return Ok(result);
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            await Service.CreateClientAsync(client);
            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var result = await Service.DeleteClientAsync(id);
            return Ok(result);
        }


    }
}
