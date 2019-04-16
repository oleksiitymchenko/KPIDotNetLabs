using System;
using System.Runtime.Serialization;
using DataAccess.InMemoryDb;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class Test : IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }
        [DataMember()]
        public string Name { get; set; }
        [DataMember()]
        public string Theme { get; set; }
        [DataMember()]
        public DateTime Date { get; set; }

        [DataMember()]
        public Guid TeacherId { get; set; }
        
        public object Clone() => new Test()
        {
            Id = this.Id,
            Name = this.Name,
            Theme = this.Theme,
            Date = this.Date,
            TeacherId = this.TeacherId
        };
    }
}
