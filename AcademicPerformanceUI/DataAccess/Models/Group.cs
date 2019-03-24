using System;
using System.Runtime.Serialization;

namespace DataAccess.Models
{
    [Serializable]
    public class Group : IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }
        [DataMember()]
        public string GroupName { get; set; }
        [DataMember()]
        public int MaxStudents { get; set; }
        [DataMember()]
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
