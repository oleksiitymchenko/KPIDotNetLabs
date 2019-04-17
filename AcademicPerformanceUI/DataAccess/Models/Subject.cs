using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Subject")]
    [Serializable]
    public class Subject : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string Name { get; set; }

        [DataMember()]
        [Column]
        public FinalTestType FinalTestType { get; set; }

        [DataMember()]
        [Column]
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
