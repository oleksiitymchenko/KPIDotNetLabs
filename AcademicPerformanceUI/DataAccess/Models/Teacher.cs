using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Subject")]
    [Serializable]
    public class Teacher : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }
        [Column]
        [DataMember()]
        public string FirstName { get; set; }
        [Column]
        [DataMember()]
        public string LastName { get; set; }
        [Column]
        [DataMember()]
        public string PhoneNumber { get; set; }

        [Column]
        [DataMember()]
        public Guid SubjectId { get; set; }
        
        public object Clone() => new Teacher()
        {
            Id = this.Id,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PhoneNumber = this.PhoneNumber,
            SubjectId = this.SubjectId
        };
    }
}
