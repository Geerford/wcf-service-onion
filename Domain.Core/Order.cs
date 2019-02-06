using System;

namespace Domain.Core
{
    public class Order
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public int ItemID { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}