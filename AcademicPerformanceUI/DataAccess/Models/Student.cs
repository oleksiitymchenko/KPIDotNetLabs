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
            set
            {
                GroupId = ObjectLists.Groups.Exists(g => g.Id == value.Id) ? 
                                                                  value.Id : 
                                                                  throw new FormatException("Group with specified Id not exists");
            }
        }
    }
}
