using System;

namespace DataAccess.Models
{
    [Serializable]
    public class Teacher : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

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
