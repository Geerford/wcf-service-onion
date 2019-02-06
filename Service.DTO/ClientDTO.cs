using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class ClientDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Midname { get; set; }
    }
}