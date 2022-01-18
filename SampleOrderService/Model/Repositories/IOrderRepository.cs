using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Model.Repositories
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetClientOrdersAsync(int client_id);
        Task<Order> GetOrderAsync(int id);
    }
}
