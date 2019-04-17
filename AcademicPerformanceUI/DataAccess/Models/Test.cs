using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Subject")]
    [Serializable]
    public class Test : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }
        [Column]
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        [Column]
        public string Theme { get; set; }
        [Column]
        [DataMember()]
        public DateTime Date { get; set; }

        [Column]
        [DataMember()]
        public Guid TeacherId { get; set; }
        
        public object Clone() => new Test()
        {
            Id = this.Id,
            Name = this.Name,
            Theme = this.Theme,
            Date = this.Date,
            TeacherId = this.TeacherId
        };
    }
}
