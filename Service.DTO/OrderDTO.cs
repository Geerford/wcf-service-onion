using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class OrderDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int ClientID { get; set; }

        [DataMember]
        public int ItemID { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}