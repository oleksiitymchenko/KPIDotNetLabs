using System;
using System.Runtime.Serialization;

namespace WebServicesShared.DTOModels
{
    [DataContract]
    public class GroupDto: IBaseDto
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
