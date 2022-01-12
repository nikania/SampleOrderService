using SampleOrderService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> GetClientOrdersAsync(int client_id)
        {
            throw new NotImplementedException();
        }
    }
}
