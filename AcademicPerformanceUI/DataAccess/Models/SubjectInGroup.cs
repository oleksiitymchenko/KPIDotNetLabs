using System;

namespace DataAccess.Models
{
    public class SubjectInGroup : IEntity
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject
        {
            get => ObjectLists.Subjects.Find((Predicate<Subject>)(o => o.Id == this.SubjectId));
        }

        public Guid GroupId { get; set; }
        public Group Group
        {
            get => ObjectLists.Groups.Find(g => g.Id == GroupId);
        }

        public object Clone() => new SubjectInGroup()
        {
            Id = this.Id,
            SubjectId = this.SubjectId,
            GroupId = this.GroupId
        };
    }
}
