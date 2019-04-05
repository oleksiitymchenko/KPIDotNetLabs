using System;
using System.Runtime.Serialization;
using DataAccess.InMemoryDb;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Serializable]
    public class TestResult:IEntity
    {
        [DataMember()]
        public Guid Id { get; set; }
        [DataMember()]
        public int Mark { get; set; }

        [DataMember()]
        public Guid TestId { get; set; }
        
        [DataMember()]
        public Guid StudentId { get; set; }
       

        public object Clone() => new TestResult()
        {
            Id = this.Id,
            Mark = this.Mark,
            TestId = this.TestId,
            StudentId = this.StudentId
        };
    }
}
