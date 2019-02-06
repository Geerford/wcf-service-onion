using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private Context database;

        public ClientRepository(Context context)
        {
            database = context;
        }

        public Client Create(Client item)
        {
            database.Client.Add(item);
            return item;
        }

        public Client Delete(int id)
        {
            Client item = database.Client.Find(id);
            if (item != null)
            {
                database.Client.Remove(item);
            }
            return item;
        }

        public IEnumerable<Client> Find(Func<Client, bool> predicate)
        {
            return database.Client.Where(predicate);
        }

        public Client FindFirst(Func<Client, bool> predicate)
        {
            return database.Client.Where(predicate).First();
        }

        public Client Get(int id)
        {
            return database.Client.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return database.Client;
        }

        public Client Update(Client item)
        {
            database.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}