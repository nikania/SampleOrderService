﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Model.Repositories
{
    public interface IClientRepository
    {
        Task<IList<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int id);
        Task<Client> ChangeClientAsync(Client client);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> DeleteClientAsync(int id);
    }
}
