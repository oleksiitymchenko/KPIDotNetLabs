using System;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class Subject : IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public FinalTestType FinalTestType { get; set; }
        [DataMember()]
        public double Hours { get; set; }

        public object Clone() => new Subject()
        {
            Id = this.Id,
            Name = this.Name,
            FinalTestType = this.FinalTestType,
            Hours = this.Hours
        };
    }
}
