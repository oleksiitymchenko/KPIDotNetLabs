using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class TestDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Theme { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Guid TeacherId { get; set; }
    }
}
