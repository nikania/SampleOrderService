using SampleOrderService.Exceptions;
using SampleOrderService.Model;
using SampleOrderService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleOrderService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await repository.GetOrderAsync(id);
            return order ?? throw new OrderNotFoundException(id);
        }

        public async Task<IList<Order>> GetClientOrdersAsync(int client_id)
        {
            return await repository.GetClientOrdersAsync(client_id);
        }
    }
}
