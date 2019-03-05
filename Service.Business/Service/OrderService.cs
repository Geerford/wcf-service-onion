using Domain.Core;
using Repository.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service.Business.Service
{
    public class OrderService : IOrderService
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

        public IEnumerable<OrderItem> GroupAllByID()
        {
            return Database.Order.GetAll().GroupBy(x => x.ItemID).Select(x => new OrderItem
            {
                Item = Database.Goods.Get(x.First().ItemID),
                Date = x.First().Date,
                Count = x.Sum(y => y.Count)
            });
        }

        public IEnumerable<OrderDTO> GetAllFull()
        {
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (var order in Database.Order.GetAll())
            {
                Customer client = Database.Client.Get(order.ClientID);
                if (client == null)
                {
                    throw new ValidationException("Сущность не найдена", "");
                }
                Goods item = Database.Goods.Get(order.ItemID);
                if (item == null)
                {
                    throw new ValidationException("Сущность не найдена", "");
                }
                orders.Add(new OrderDTO(client, item, order));
            }
            return orders;
        }        

        public CartDTO GetByClient(int? clientID)
        {
            if (clientID == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Customer client = Database.Client.Get(clientID.Value);
            if (client == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            List<OrderItem> orders = new List<OrderItem>();
            foreach(var order in Database.Order.GetAll().Where(x => x.ClientID == clientID))
            {
                Goods item = Database.Goods.Get(order.ItemID);
                if (item == null)
                {
                    throw new ValidationException("Сущность не найдена", "");
                }
                orders.Add(new OrderItem
                {
                    Count = order.Count,
                    Date = order.Date,
                    Item = item
                });
            }

            return new CartDTO
            {
                Client = client,
                Items = orders
            };
        }

        public OrderDTO GetFull(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не задан ID", "");
            }
            Order order = Database.Order.Get(id.Value);
            if (order == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            Customer client = Database.Client.Get(order.ClientID);
            if (client == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            Goods item = Database.Goods.Get(order.ItemID);
            if (item == null)
            {
                throw new ValidationException("Сущность не найдена", "");
            }
            return new OrderDTO(client, item, order);
        }
    }
}