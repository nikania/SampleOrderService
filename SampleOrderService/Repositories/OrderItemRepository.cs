using Microsoft.EntityFrameworkCore;
using SampleOrderService.Exceptions;
using SampleOrderService.Model;
using SampleOrderService.Model.Repositories;
using SampleOrderService.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Repositories
{
    public class OrderItemRepository : EFRepoBase, IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context) : base(context)
        {
        }

        public async Task<OrderItem> DeleteOrderItemAsync(int id)
        {
            return await Process(async () =>
            {
                var orderItem = await DbContext.OrderItems.FindAsync(id);
                if (orderItem == null)
                {
                    throw new OrderItemNotFoundException(id);
                }

                DbContext.OrderItems.Remove(orderItem);
                await DbContext.SaveChangesAsync();

                return orderItem;
            });
        }

        public async Task<OrderItem> GetOrderItemAsync(int id)
        {
            return await Process(async () =>
            {
                var orderItem = await DbContext.OrderItems.FindAsync(id);

                if (orderItem == null)
                {
                    throw new OrderItemNotFoundException(id);
                }

                return orderItem;
            });
        }

        public async Task<IList<OrderItem>> GetOrderItemsAsync(int order_id)
        {
            return await Process(async () =>
            {
                return await DbContext.OrderItems
                                .Where(x => x.OrderId == order_id)
                                .AsNoTracking()
                                .ToListAsync();
            });
        }

        public async Task<OrderItem> PostOrderItemAsync(OrderItem item)
        {
            return await Process(async () =>
            {
                DbContext.OrderItems.Add(item);
                await DbContext.SaveChangesAsync();

                return item;
            });
        }

        public async Task<OrderItem> PutOrderItemAsync(OrderItem item)
        {
            return await Process(async () =>
            {
                if (!await OrderItemExistsAsync(item.Id))
                {
                    throw new OrderItemNotFoundException(item.Id);
                }

                DbContext.Entry(item).State = EntityState.Modified;

                await DbContext.SaveChangesAsync();

                return item;
            });
        }

        private async Task<bool> OrderItemExistsAsync(int id)
        {
            return await DbContext.OrderItems.AnyAsync(e => e.Id == id);
        }
    }
}
