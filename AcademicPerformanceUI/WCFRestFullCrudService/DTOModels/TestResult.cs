using System;
using System.Runtime.Serialization;

namespace WCFRestFullCrudService.DTOModels
{
    [DataContract]
    public class TestResult: IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public int Mark { get; set; }

        [DataMember]
        public Guid TestId { get; set; }

        [DataMember]
        public Guid StudentId { get; set; }
    }
}
