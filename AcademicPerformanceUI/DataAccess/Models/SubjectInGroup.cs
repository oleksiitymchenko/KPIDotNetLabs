using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "SubjectInGroup")]
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

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (SubjectInGroup)mapFrom;
            this.Id = entity.Id;
            this.SubjectId = entity.SubjectId;
            this.GroupId = entity.GroupId;

            return this;
        }
    }
}
