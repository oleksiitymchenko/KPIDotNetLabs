using System;

namespace DataAccess.Models
{
    public class Group : IEntity
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int MaxStudents { get; set; }
        public int StudyYear { get; set; }

        public object Clone()
        {
            return new Group()
            {
                Id = this.Id,
                GroupName = this.GroupName,
                MaxStudents = this.MaxStudents,
                StudyYear = this.StudyYear
            };
        }
    }
}
