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
        public async Task<IActionResult> GetOrders()
        {
            return await ProcessAsync(async () =>
            {
                await Task.CompletedTask;
                return Ok(new Order() { CreatedAt = DateTime.Now });
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            return await ProcessAsync(async () =>
            {
                await Task.CompletedTask;
                return Ok(new Order() { Id = id, CreatedAt = DateTime.Now });
            });
        }

    }
}
