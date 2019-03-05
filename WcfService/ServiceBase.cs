using Domain.Core;
using Infrastructure.Data;
using Service.Business.Service;
using Service.DTO;
using Service.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WcfService
{
    public abstract class ServiceBase
    {
        private IService<Customer> customersService;
        private IService<Goods> goodsService;
        private IOrderService orderService;
        private UnitOfWork unitOfWork;

        public ServiceBase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WcfContext"].ConnectionString;
            unitOfWork = new UnitOfWork(connectionString);
            customersService = new ClientService(unitOfWork);
            goodsService = new GoodsService(unitOfWork);
            orderService = new OrderService(unitOfWork);
        }

        public IEnumerable<CustomerDTO> GetClientsInternal()
        {
            return customersService.GetAll().Select(x => new CustomerDTO
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                Midname = x.Midname,
                Cart = GetByClient(x.ID)
            }).ToList();
        }

        private CartDTO GetByClient(int clientID)
        {
            return orderService.GetByClient(clientID);
        }

        public IEnumerable<GoodsDTO> GetGoodsInternal()
        {
            return goodsService.GetAll().Select(x => new GoodsDTO
            {
                ID = x.ID,
                Title = x.Title,
                Type = x.Type
            }).ToList();
        }
    }
}