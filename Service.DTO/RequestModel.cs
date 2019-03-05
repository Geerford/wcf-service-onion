using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class RequestModel
    {
        [DataMember]
        public int GetCustumerRequest = 0;

        [DataMember]
        public int GetGoodsRequest = 0;

        [DataMember]
        public int TotalRequest = 0;
    }
}