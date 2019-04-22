using System;
using System.Runtime.Serialization;

namespace WcfRestService.DTOModels
{
    [DataContract]
    public class SubjectInGroupDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid SubjectId { get; set; }

        [DataMember]
        public Guid GroupId { get; set; }
    }
}
