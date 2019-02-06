using Domain.Core;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Business.Service
{
    public class ItemService : IService<Item>
    {
        IUnitOfWork Database { get; set; }

        public ItemService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public Item Create(Item item)
        {
            Database.Item.Create(item);
            Database.Save();
            return item;
        }

        public Item Delete(Item item)
        {
            Database.Item.Delete(item.ID);
            Database.Save();
            return item;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Item Edit(Item item)
        {
            Database.Item.Update(item);
            Database.Save();
            return item;
        }

        public Item Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Item item = Database.Item.Get(id.Value);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return item;
        }

        public IEnumerable<Item> GetAll()
        {
            return Database.Item.GetAll();
        }
    }
}
