using Domain.Core;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Business.Service
{
    public class OrderService : IService<Order>
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Order Create(Order item)
        {
            Database.Order.Create(item);
            Database.Save();
            return item;
        }

        public Order Delete(Order item)
        {
            Database.Order.Delete(item.ID);
            Database.Save();
            return item;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Order Edit(Order item)
        {
            Database.Order.Update(item);
            Database.Save();
            return item;
        }

        public Order Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Order item = Database.Order.Get(id.Value);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return item;
        }

        public IEnumerable<Order> GetAll()
        {
            return Database.Order.GetAll();
        }
    }
}