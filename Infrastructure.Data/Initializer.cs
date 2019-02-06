using Domain.Core;
using System.Data.Entity;

namespace Infrastructure.Data
{
    internal class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context database)
        {
            database.Client.Add(new Client
            {
                Name = "Anthony",
                Surname = "Marston",
                Midname = "James"
            });
            database.Client.Add(new Client
            {
                Name = "Ethel",
                Surname = "Rogers"
            });
            database.Client.Add(new Client
            {
                Name = "John",
                Surname = "MacArthur",
                Midname = "Gordon"
            });
            database.Client.Add(new Client
            {
                Name = "John",
                Surname = "Wargrave",
                Midname = "Lawrence"
            });
            database.Client.Add(new Client
            {
                Name = "Edward",
                Surname = "Armstrong",
                Midname = "George"
            });
            database.Client.Add(new Client
            {
                Name = "William",
                Surname = "Blore",
                Midname = "Henry"
            });
            database.Client.Add(new Client
            {
                Name = "Philip",
                Surname = "Lombard"
            });
            database.Item.Add(new Item
            {
                Title = "Item №1",
                Type = "Type №1"
            });
            database.Item.Add(new Item
            {
                Title = "Item №2",
                Type = "Type №2"
            });
            database.Item.Add(new Item
            {
                Title = "Item №3",
                Type = "Type №3"
            });
            database.Item.Add(new Item
            {
                Title = "Item №4",
                Type = "Type №4"
            });
            database.Item.Add(new Item
            {
                Title = "Item №5",
                Type = "Type №5"
            });
            database.Item.Add(new Item
            {
                Title = "Item №6",
                Type = "Type №6"
            });
            database.SaveChanges();
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 1,
                Count = 2
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 2,
                Count = 1
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 3,
                Count = 3
            });
            database.Order.Add(new Order
            {
                ClientID = 1,
                ItemID = 4,
                Count = 1
            });
            database.Order.Add(new Order
            {
                ClientID = 3,
                ItemID = 6,
                Count = 1
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 5,
                Count = 1
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 4,
                Count = 6
            });
            database.Order.Add(new Order
            {
                ClientID = 2,
                ItemID = 1,
                Count = 5
            });
            database.Order.Add(new Order
            {
                ClientID = 4,
                ItemID = 4,
                Count = 2
            });
            database.Order.Add(new Order
            {
                ClientID = 5,
                ItemID = 2,
                Count = 1
            });
            database.Order.Add(new Order
            {
                ClientID = 6,
                ItemID = 3,
                Count = 1
            });
            database.SaveChanges();
        }
    }
}