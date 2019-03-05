using Domain.Core;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Customer> Client { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<Order> Order { get; set; }

        static Context()
        {
            Database.SetInitializer(new Initializer());
        }

        public Context(string connectionString) : base(connectionString) { }
    }
}