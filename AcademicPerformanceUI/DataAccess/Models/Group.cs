using System;
using DataAccess.Interfaces;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace DataAccess.Models
{
    [Serializable]
    [Table(Name = "Group")]
    public class Group : IEntity
    {
        [DataMember()]
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }

        [DataMember()]
        [Column]
        public string GroupName { get; set; }

        [DataMember()]
        [Column]
        public int MaxStudents { get; set; }

        [DataMember()]
        [Column]
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

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Group)mapFrom;
            this.Id = entity.Id;
            this.GroupName = entity.GroupName;
            this.MaxStudents = entity.MaxStudents;
            this.StudyYear = entity.StudyYear;

            return this;
        }
    }
}
