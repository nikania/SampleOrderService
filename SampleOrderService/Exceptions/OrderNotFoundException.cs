namespace SampleOrderService.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int id) : base($"Order [{id}] not found.")
        {
        }
    }
}
