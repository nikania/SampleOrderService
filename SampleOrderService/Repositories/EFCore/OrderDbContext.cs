using Microsoft.EntityFrameworkCore;
using SampleOrderService.Model;
using System.Reflection;

#nullable disable
namespace SampleOrderService.Repositories.EFCore
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options): base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
