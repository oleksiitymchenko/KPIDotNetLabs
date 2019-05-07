using System;
using System.Runtime.Serialization;

namespace WebServicesShared.DTOModels
{
    [DataContract]
    public class TeacherDto : IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public Guid SubjectId { get; set; }
    }
}
