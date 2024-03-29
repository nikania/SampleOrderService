﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Model.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IList<OrderItem>> GetOrderItemsAsync(int order_id);
        Task<OrderItem> GetOrderItemAsync(int id);
        Task<OrderItem> ChangeOrderItemAsync(OrderItem item);
        Task<OrderItem> CreateOrderItemAsync(OrderItem item);
        Task<OrderItem> DeleteOrderItemAsync(int id);
    }
}
