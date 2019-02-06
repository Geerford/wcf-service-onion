﻿using System.Runtime.Serialization;

namespace Service.DTO
{
    [DataContract]
    public class ItemDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}