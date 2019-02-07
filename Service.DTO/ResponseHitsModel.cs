using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class ResponseHitsModel
    {
        [DataMember]
        public int GetClientsRequest { get; set; }

        [DataMember]
        public int GetOrdersRequest { get; set; }

        [DataMember]
        public int GetGoodsRequest { get; set; }

        [DataMember]
        public int GetByClientRequest { get; set; }

        [DataMember]
        public int TotalRequest { get; set; }
    }
}