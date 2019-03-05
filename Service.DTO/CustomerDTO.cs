using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class CustomerDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Midname { get; set; }

        [DataMember]
        public CartDTO Cart { get; set; }
    }
}