using Microsoft.EntityFrameworkCore;
using SampleOrderService.Model;
using SampleOrderService.Model.Repositories;
using SampleOrderService.Repositories.EFCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Repositories
{
    public class OrderRepository : EFRepoBase, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {
        }

        public async Task<IList<Order>> GetClientOrdersAsync(int client_id)
        {
            return await Process(async () =>
            {
                return await DbContext.Orders
                    .Where(o => o.ClientId == client_id)
                    .AsNoTracking()
                    .ToListAsync();
            });
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await Process(async () =>
            {
                return await DbContext.Orders
                    .FindAsync(id);
            });
        }
    }
}
