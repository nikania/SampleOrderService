namespace SampleOrderService.Exceptions
{
    public class ClientNotFoundException : NotFoundException
    {
        public ClientNotFoundException(int id) : base($"Client with id [{id}] not found.")
        {
        }
    }
}
