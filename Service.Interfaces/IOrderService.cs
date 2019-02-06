using Domain.Core;
using Service.DTO;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        Order Create(Order model);

        Order Delete(Order model);

        void Dispose();

        Order Edit(Order model);

        Order Get(int? id);

        IEnumerable<Order> GetAll();

        IEnumerable<OrderDTO> GetAllFull();
       
        CartDTO GetByClient(int? clientID);

        OrderDTO GetFull(int? id);

        IEnumerable<OrderItem> GroupAllByID();
    }
}