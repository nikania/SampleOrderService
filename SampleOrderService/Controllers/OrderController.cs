using Microsoft.AspNetCore.Mvc;
using SampleOrderService.Model;
using SampleOrderService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Controllers
{
    [Route("api/1.0.0/order")]
    public class OrderController : BaseController<IOrderService>
    {
        public OrderController(IOrderService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetClientOrders([FromQuery] int client_id)
        {
            return await ProcessAsync(async () =>
            {
                var orders = await Service.GetClientOrdersAsync(client_id);
                return Ok(orders);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            return await ProcessAsync(async () =>
            {
                var order = await Service.GetOrderAsync(id);
                return Ok(order);
            });
        }

    }
}
