using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class ClientRepository : IRepository<Customer>
    {
        private Context database;

        public ClientRepository(Context context)
        {
            database = context;
        }

        public Customer Create(Customer item)
        {
            database.Client.Add(item);
            return item;
        }

        public Customer Delete(int id)
        {
            Customer item = database.Client.Find(id);
            if (item != null)
            {
                database.Client.Remove(item);
            }
            return item;
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return database.Client.Where(predicate);
        }

        public Customer FindFirst(Func<Customer, bool> predicate)
        {
            return database.Client.Where(predicate).First();
        }

        public Customer Get(int id)
        {
            return database.Client.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return database.Client;
        }

        public Customer Update(Customer item)
        {
            database.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}