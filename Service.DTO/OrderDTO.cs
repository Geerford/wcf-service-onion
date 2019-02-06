using Domain.Core;
using System;
using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public Client Client { get; set; }

        [DataMember]
        public Goods Item { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Count { get; set; }

        public OrderDTO(Client client, Goods item, Order order)
        {
            ID = order.ID;
            Client = client;
            Item = item;
            Date = order.Date;
            Count = order.Count;
        }
    }
}