using Domain.Core;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Business.Service
{
    public class ClientService : IService<Customer>
    {
        IUnitOfWork Database { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Customer Create(Customer item)
        {
            Database.Client.Create(item);
            Database.Save();
            return item;
        }

        public Customer Delete(Customer item)
        {
            Database.Client.Delete(item.ID);
            Database.Save();
            return item;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Customer Edit(Customer item)
        {
            Database.Client.Update(item);
            Database.Save();
            return item;
        }

        public Customer Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Customer item = Database.Client.Get(id.Value);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return item;
        }

        public IEnumerable<Customer> GetAll()
        {
            return Database.Client.GetAll();
        }
    }
}