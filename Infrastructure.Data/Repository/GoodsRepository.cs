using Domain.Contracts;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class GoodsRepository : IRepository<Goods>
    {
        private Context database;

        public GoodsRepository(Context context)
        {
            database = context;
        }

        public Goods Create(Goods item)
        {
            database.Goods.Add(item);
            return item;
        }

        public Goods Delete(int id)
        {
            Goods item = database.Goods.Find(id);
            if (item != null)
            {
                database.Goods.Remove(item);
            }
            return item;
        }

        public IEnumerable<Goods> Find(Func<Goods, bool> predicate)
        {
            return database.Goods.Where(predicate);
        }

        public Goods FindFirst(Func<Goods, bool> predicate)
        {
            return database.Goods.Where(predicate).First();
        }

        public Goods Get(int id)
        {
            return database.Goods.Find(id);
        }

        public IEnumerable<Goods> GetAll()
        {
            return database.Goods;
        }

        public Goods Update(Goods item)
        {
            database.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
