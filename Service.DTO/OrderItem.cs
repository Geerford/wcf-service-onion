using Domain.Core;
using System;
using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Goods Item { get; set; }
    }
}