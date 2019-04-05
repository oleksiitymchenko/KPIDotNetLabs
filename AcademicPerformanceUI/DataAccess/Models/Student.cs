using System;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class Student : IEntity
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
        public Guid GroupId { get; set; }
        public Group Group
        {
            get => InMemory.Groups.Find(g => g.Id == GroupId);
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
