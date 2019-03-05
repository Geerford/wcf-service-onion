using Domain.Contracts;
using Domain.Core;
using System;

namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Client { get; }

        IRepository<Goods> Goods { get; }

        IRepository<Order> Order { get; }

        void Save();
    }
}