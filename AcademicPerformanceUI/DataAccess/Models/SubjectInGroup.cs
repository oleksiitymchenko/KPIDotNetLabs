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
        public Subject Subject
        {
            get => InMemory.Subjects.Find((Predicate<Subject>)(o => o.Id == this.SubjectId));
        }

        [DataMember()]
        public Guid GroupId { get; set; }
        public Group Group
        {
            get => InMemory.Groups.Find(g => g.Id == GroupId);
        }

        public object Clone() => new SubjectInGroup()
        {
            Id = this.Id,
            SubjectId = this.SubjectId,
            GroupId = this.GroupId
        };
    }
}
