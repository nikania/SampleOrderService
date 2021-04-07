using System.Collections.Generic;

namespace SampleOrderService.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public List<Order>? Orders { get; set; }
    }
}