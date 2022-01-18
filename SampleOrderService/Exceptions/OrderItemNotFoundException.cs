namespace SampleOrderService.Exceptions
{
    public class OrderItemNotFoundException : NotFoundException
    {
        public OrderItemNotFoundException(int id) : base($"Order Item [{id}] not found.")
        {
        }
    }
}
