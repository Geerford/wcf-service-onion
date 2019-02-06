using Domain.Core;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Business.Service
{
    public class GoodsService : IService<Goods>
    {
        IUnitOfWork Database { get; set; }

        public GoodsService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public Goods Create(Goods item)
        {
            Database.Goods.Create(item);
            Database.Save();
            return item;
        }

        public Goods Delete(Goods item)
        {
            Database.Goods.Delete(item.ID);
            Database.Save();
            return item;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Goods Edit(Goods item)
        {
            Database.Goods.Update(item);
            Database.Save();
            return item;
        }

        public Goods Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Goods item = Database.Goods.Get(id.Value);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return item;
        }

        public IEnumerable<Goods> GetAll()
        {
            return Database.Goods.GetAll();
        }
    }
}
