using Domain.Core;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Order> Order { get; set; }

        static Context()
        {
            Database.SetInitializer(new Initializer());
        }

        public Context(string connectionString) : base(connectionString) { }
    }
}