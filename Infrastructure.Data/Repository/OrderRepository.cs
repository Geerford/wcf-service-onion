using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private Context database;

        public OrderRepository(Context context)
        {
            database = context;
        }

        public Order Create(Order item)
        {
            database.Order.Add(item);
            return item;
        }

        public Order Delete(int id)
        {
            Order item = database.Order.Find(id);
            if (item != null)
            {
                database.Order.Remove(item);
            }
            return item;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return database.Order.Where(predicate);
        }

        public Order FindFirst(Func<Order, bool> predicate)
        {
            return database.Order.Where(predicate).First();
        }

        public Order Get(int id)
        {
            return database.Order.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return database.Order;
        }

        public Order Update(Order item)
        {
            database.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}