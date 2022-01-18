using SampleOrderService.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Services
{
    public interface IOrderItemService : IService
    {
        Task<IList<OrderItem>> GetOrderItemsAsync(int order_id);
        Task<OrderItem> GetOrderItemAsync(int id);
        Task<OrderItem> ChangeOrderItemAsync(OrderItem item);
        Task<OrderItem> CreateOrderItemAsync(OrderItem item);
        Task<OrderItem> DeleteOrderItemAsync(int id);
    }
}
