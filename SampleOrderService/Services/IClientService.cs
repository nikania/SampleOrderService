using SampleOrderService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Services
{
    public interface IClientService : IService
    {
        Task<IList<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int id);
        Task<Client> ChangeClientAsync(Client client);
        Task<Client> CreateClientAsync(Client client);
        Task<Client> DeleteClientAsync(int id);
    }
}
