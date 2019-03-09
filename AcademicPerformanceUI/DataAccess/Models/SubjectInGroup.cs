using System;

namespace DataAccess.Models
{
    public class SubjectInGroup : IEntity
    {
        public Guid Id { get; set; }

        private Guid SubjectId;
        public Subject Subject
        {
            get => ObjectLists.Subjects.Find(o => o.Id == SubjectId);
            set
            {
                SubjectId = ObjectLists.Subjects.Exists(s => s.Id == value.Id)
                    ? value.Id
                    : throw new FormatException("Subject with specified Id not exists");
            }
        }

        private Guid GroupId { get; set; }
        public Group Group
        {
            get => ObjectLists.Groups.Find(g => g.Id == GroupId);
            set
            {
                GroupId = ObjectLists.Groups.Exists(g => g.Id == value.Id) ?
                                                                  value.Id :
                                                                  throw new FormatException("Group with specified Id not exists");
            }
        }
    }
}
