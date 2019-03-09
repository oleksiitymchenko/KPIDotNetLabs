using System;

namespace DataAccess.Models
{
    public class Teacher : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject
        {
            get => ObjectLists.Subjects.Find(s => s.Id == SubjectId);
            set
            {
                SubjectId = ObjectLists.Subjects.Exists(s => s.Id == value.Id) 
                    ? value.Id 
                    : throw new FormatException("Subject with specified Id not exists"); 
            }
        }
    }
}
