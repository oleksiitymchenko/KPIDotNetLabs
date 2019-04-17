using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.InMemoryDb;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    [Table(Name = "Student")]
    public class Student : IEntity
    {
        [DataMember()]
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public Guid Id { get; set; }
        [DataMember()]
        [Column]
        public string FirstName { get; set; }
        [DataMember()]
        [Column]
        public string LastName { get; set; }
        [DataMember()]
        [Column]
        public string PhoneNumber { get; set; }
        [DataMember()]
        [Column]
        public Guid GroupId { get; set; }
       
        public object Clone() => new Student()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                GroupId = this.GroupId
            };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (Student)mapFrom;
            this.Id = entity.Id;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.PhoneNumber = entity.PhoneNumber;
            this.GroupId = entity.GroupId;

            return this;
        }
    }
}
