using System;

namespace DataAccess.Models
{
    public class Student : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Guid GroupId { get; set; }
        public Group Group
        {
            get => ObjectLists.Groups.Find(g => g.Id == GroupId);
        }

        public object Clone() => new Student()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                GroupId = this.GroupId
            };
    }
}
