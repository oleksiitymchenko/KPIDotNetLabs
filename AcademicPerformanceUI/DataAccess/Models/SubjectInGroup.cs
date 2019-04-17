using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "Subject")]
    [Serializable]
    public class SubjectInGroup : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }

        [Column]
        [DataMember()]
        public Guid SubjectId { get; set; }
       
        [Column]
        [DataMember()]
        public Guid GroupId { get; set; }
       
        public object Clone() => new SubjectInGroup()
        {
            Id = this.Id,
            SubjectId = this.SubjectId,
            GroupId = this.GroupId
        };
    }
}
