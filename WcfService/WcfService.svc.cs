using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using Domain.Core;
using Infrastructure.Data;
using Service.Business.Service;
using Service.DTO;
using Service.Interfaces;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfService : IWcfService
    {
        IService<Client> clientService;
        IService<Goods> itemService;
        IOrderService orderService;
        UnitOfWork unitOfWork;
        ResponseHitsModel counter;
        object _lock = new object();

        public WcfService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            unitOfWork = new UnitOfWork(connectionString);
            clientService = new ClientService(unitOfWork);
            itemService = new GoodsService(unitOfWork);
            orderService = new OrderService(unitOfWork);
            counter = new ResponseHitsModel();
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            lock (_lock) {
                ++counter.GetClientsRequest;
                ++counter.TotalRequest;
            }
            return clientService.GetAll().Select(x => new ClientDTO
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                Midname = x.Midname
            }).ToList();
        }

        public IEnumerable<GoodsDTO> GetGoods()
        {
            lock (_lock)
            {
                ++counter.GetGoodsRequest;
                ++counter.TotalRequest;
            }
            Thread.Sleep(1);
            return itemService.GetAll().Select(x => new GoodsDTO
            {
                ID = x.ID,
                Title = x.Title,
                Type = x.Type
            }).ToList();
        }

        public CartDTO GetByClient(int clientID)
        {
            lock (_lock)
            {
                ++counter.GetByClientRequest;
                ++counter.TotalRequest;
            }
            return orderService.GetByClient(clientID);
        }

        public IEnumerable<OrderItem> GetOrdersGroup()
        {
            lock (_lock)
            {
                ++counter.GetOrdersRequest;
                ++counter.TotalRequest;
            }
            return orderService.GroupAllByID();
        }

        public ResponseHitsModel TotalHits()
        {
            return counter;
        }
    }
}