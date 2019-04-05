using System;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class Teacher : IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }
        [DataMember()]
        public string FirstName { get; set; }
        [DataMember()]
        public string LastName { get; set; }
        [DataMember()]
        public string PhoneNumber { get; set; }

        [DataMember()]
        public Guid SubjectId { get; set; }
        public Subject Subject
        {
            get => InMemory.Subjects.Find(s => s.Id == SubjectId);
        }

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
