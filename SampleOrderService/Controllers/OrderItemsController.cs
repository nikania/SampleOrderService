using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleOrderService.Model;
using SampleOrderService.Repositories.EFCore;
using SampleOrderService.Services;

namespace SampleOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : BaseController<IOrderItemService>
    {

        public OrderItemsController(IOrderItemService service) : base(service)
        {
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems([FromQuery] int order_id)
        {
            var result = await Service.GetOrderItemsAsync(order_id);
            return Ok(result);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            var result = await Service.GetOrderItemAsync(id);
            return Ok(result);
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }

            var result = await Service.ChangeOrderItemAsync(orderItem);
            return Ok(result);
        }

        // POST: api/OrderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {

            var result = await Service.CreateOrderItemAsync(orderItem);
            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> DeleteOrderItem(int id)
        {
            var result = await Service.DeleteOrderItemAsync(id);
            return Ok(result);
        }


    }
}
