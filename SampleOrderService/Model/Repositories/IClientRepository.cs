using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Model.Repositories
{
    public interface IClientRepository
    {
        Task<IList<Client>> GetClientsAsync();
        Task<Client> GetClientAsync(int id);
        Task<Client> PutClientAsync(Client client);
        Task<Client> PostClientAsync(Client client);
        Task<Client> DeleteClientAsync(int id);
    }
}
