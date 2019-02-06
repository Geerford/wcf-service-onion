using Domain.Contracts;
using Domain.Core;
using System;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Client { get; }

        IRepository<Item> Item { get; }

        IRepository<Order> Order { get; }

        void Save();
    }
}