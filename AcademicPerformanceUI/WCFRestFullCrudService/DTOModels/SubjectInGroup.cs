using System;
using System.Runtime.Serialization;

namespace WCFRestFullCrudService.DTOModels
{
    [DataContract]
    public class SubjectInGroup: IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid SubjectId { get; set; }

        [DataMember]
        public Guid GroupId { get; set; }
    }
}
