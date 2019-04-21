using System;
using System.Runtime.Serialization;

namespace WCFRestFullCrudService.DTOModels
{
    [DataContract]
    public class Subject: IBaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public FinalTestType FinalTestType { get; set; }

        [DataMember]
        public double Hours { get; set; }
    }
}
