﻿using Domain.Contracts;
using Domain.Core;
using Infrastructure.Data.Repository;
using Repository.Interfaces;
using System;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context database;

        private bool disposed = false;

        private ClientRepository ClientRepository;

        private GoodsRepository ItemRepository;

        private OrderRepository OrderRepository;

        public UnitOfWork(string connectionString)
        {
            database = new Context(connectionString);
        }

        public IRepository<Customer> Client
        {
            get
            {
                if (ClientRepository == null)
                {
                    ClientRepository = new ClientRepository(database);
                }
                return ClientRepository;
            }
        }

        public IRepository<Goods> Goods
        {
            get
            {
                if (ItemRepository == null)
                {
                    ItemRepository = new GoodsRepository(database);
                }
                return ItemRepository;
            }
        }

        public IRepository<Order> Order
        {
            get
            {
                if (OrderRepository == null)
                {
                    OrderRepository = new OrderRepository(database);
                }
                return OrderRepository;
            }
        }

        public void Save()
        {
            database.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    database.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}