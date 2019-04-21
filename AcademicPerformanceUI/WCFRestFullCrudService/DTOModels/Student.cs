using System;
using System.Runtime.Serialization;

namespace WCFRestFullCrudService.DTOModels
{
    [DataContract]
    public class Student: IBaseDto
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
        public Guid GroupId { get; set; }
    }
}
