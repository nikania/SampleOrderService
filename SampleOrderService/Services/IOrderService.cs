using SampleOrderService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Services
{
    public interface IOrderService : IService
    {
        Task<IList<Order>> GetClientOrdersAsync(int client_id);
        Task<Order> GetOrderAsync(int id);
    }
}
