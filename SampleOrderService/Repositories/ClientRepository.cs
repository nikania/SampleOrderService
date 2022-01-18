using Microsoft.EntityFrameworkCore;
using SampleOrderService.Exceptions;
using SampleOrderService.Model;
using SampleOrderService.Model.Repositories;
using SampleOrderService.Repositories.EFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Repositories
{
    public class ClientRepository : EFRepoBase, IClientRepository
    {
        public ClientRepository(OrderDbContext context) : base(context)
        {
        }

        public async Task<Client> DeleteClientAsync(int id)
        {
            return await Process(async () =>
            {
                var client = await DbContext.Clients.FindAsync(id);
                if (client == null)
                {
                    throw new ClientNotFoundException(id);
                }

                DbContext.Clients.Remove(client);
                await DbContext.SaveChangesAsync();

                return client;
            });
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await Process(async () =>
            {
                var client = await DbContext.Clients.FindAsync(id);

                if (client == null)
                {
                    throw new ClientNotFoundException(id);
                }

                return client;
            });
        }

        public async Task<IList<Client>> GetClientsAsync()
        {
            return await Process(async () =>
            {
                return await DbContext.Clients.ToListAsync();
            });
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            return await Process(async () =>
            {
                DbContext.Clients.Add(client);
                await DbContext.SaveChangesAsync();

                return client;
            });
        }

        public async Task<Client> ChangeClientAsync(Client client)
        {
            return await Process(async () =>
            {
                if(!await ClientExistsAsync(client.Id))
                    throw new ClientNotFoundException(client.Id);

                DbContext.Entry(client).State = EntityState.Modified;

                await DbContext.SaveChangesAsync();

                return client;
            });
        }

        private async Task<bool> ClientExistsAsync(int id)
        {
            return await DbContext.Clients.AnyAsync(e => e.Id == id);
        }
    }
}
