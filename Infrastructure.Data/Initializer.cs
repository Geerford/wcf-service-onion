using Domain.Core;
using System;
using System.Data.Entity;

namespace Infrastructure.Data
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context database)
        {
            database.Client.Add(new Customer
            {
                Name = "Anthony",
                Surname = "Marston",
                Midname = "James"
            });
            database.Client.Add(new Customer
            {
                Name = "Ethel",
                Surname = "Rogers"
            });
            database.Client.Add(new Customer
            {
                Name = "John",
                Surname = "MacArthur",
                Midname = "Gordon"
            });
            database.Client.Add(new Customer
            {
                Name = "John",
                Surname = "Wargrave",
                Midname = "Lawrence"
            });
            database.Client.Add(new Customer
            {
                Name = "Edward",
                Surname = "Armstrong",
                Midname = "George"
            });
            database.Client.Add(new Customer
            {
                Name = "William",
                Surname = "Blore",
                Midname = "Henry"
            });
            database.Client.Add(new Customer
            {
                Name = "Philip",
                Surname = "Lombard"
            });
            database.Goods.Add(new Goods
            {
                Title = "Lamb",
                Type = "Meat"
            });
            database.Goods.Add(new Goods
            {
                Title = "Coffee",
                Type = "Drink"
            });
            database.Goods.Add(new Goods
            {
                Title = "Bread",
                Type = "Flour"
            });
            database.Goods.Add(new Goods
            {
                Title = "Shortcake",
                Type = "Flour"
            });
            database.Goods.Add(new Goods
            {
                Title = "Mackerel",
                Type = "Fish"
            });
            database.Goods.Add(new Goods
            {
                Title = "Cheddar",
                Type = "Cheese"
            });
            database.SaveChanges();
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 1,
                Count = 2,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 2,
                Count = 1,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 3,
                Count = 3,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 4,
                Count = 1,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 3,
                ItemID = 6,
                Count = 1,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 5,
                Count = 1,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 4,
                Count = 6,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 1,
                Count = 5,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 4,
                ItemID = 4,
                Count = 2,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 5,
                ItemID = 2,
                Count = 1,
                Date = DateTime.Now
            });
            database.Order.Add(new Order
            {
                ClientID = 6,
                ItemID = 3,
                Count = 1,
                Date = DateTime.Now
            });
            database.SaveChanges();
        }
    }
}