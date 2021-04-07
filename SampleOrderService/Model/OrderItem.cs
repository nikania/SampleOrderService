namespace SampleOrderService.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}