using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Domain.Core;
using Infrastructure.Data;
using Service.Business.Service;
using Service.DTO;
using Service.Interfaces;

namespace WcfService
{
    public class WcfService : IWcfService
    {
        IService<Client> clientService;
        IService<Item> itemService;
        UnitOfWork unitOfWork;

        public WcfService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            unitOfWork = new UnitOfWork(connectionString);
            clientService = new ClientService(unitOfWork);
            itemService = new ItemService(unitOfWork);
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            return clientService.GetAll().Select(x => new ClientDTO
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                Midname = x.Midname
            }).ToList();
        }

        public IEnumerable<ClientDTO> GetOrders(int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
