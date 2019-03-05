using Domain.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class CartDTO
    {
        [DataMember]
        public Customer Client { get; set; }

        [DataMember]
        public IEnumerable<OrderItem> Items { get; set; }
    }
}