using System;
using System.Runtime.Serialization;

namespace WCFRestFullCrudService.DTOModels
{
    [DataContract]
    public class Group: IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public int MaxStudents { get; set; }

        [DataMember]
        public int StudyYear { get; set; }
    }
}
