using System;
using System.Runtime.Serialization;
using DataAccess.InMemoryDb;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class SubjectInGroup : IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }

        [DataMember()]
        public Guid SubjectId { get; set; }
       
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
