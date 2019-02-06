using Domain.Core;
using Repository.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;

namespace Service.Business.Service
{
    public class ClientService : IService<Client>
    {
        IUnitOfWork Database { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Client Create(Client item)
        {
            Database.Client.Create(item);
            Database.Save();
            return item;
        }

        public Client Delete(Client item)
        {
            Database.Client.Delete(item.ID);
            Database.Save();
            return item;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public Client Edit(Client item)
        {
            Database.Client.Update(item);
            Database.Save();
            return item;
        }

        public Client Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Client item = Database.Client.Get(id.Value);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return item;
        }

        public IEnumerable<Client> GetAll()
        {
            return Database.Client.GetAll();
        }
    }
}