using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class ItemRepository : IRepository<Item>
    {
        private Context database;

        public ItemRepository(Context context)
        {
            database = context;
        }

        public Item Create(Item item)
        {
            database.Item.Add(item);
            return item;
        }

        public Item Delete(int id)
        {
            Item item = database.Item.Find(id);
            if (item != null)
            {
                database.Item.Remove(item);
            }
            return item;
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate)
        {
            return database.Item.Where(predicate);
        }

        public Item FindFirst(Func<Item, bool> predicate)
        {
            return database.Item.Where(predicate).First();
        }

        public Item Get(int id)
        {
            return database.Item.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return database.Item;
        }

        public Item Update(Item item)
        {
            database.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
