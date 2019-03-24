using System;
using System.Runtime.Serialization;

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
        
        public Test Test
        {
            get => InMemory.Tests.Find(o => o.Id == TestId);
        }

        [DataMember()]
        public Guid StudentId { get; set; }
        public Student Student
        {
            get => InMemory.Students.Find(o => o.Id == StudentId);
        }

        public object Clone() => new TestResult()
        {
            Id = this.Id,
            Mark = this.Mark,
            TestId = this.TestId,
            StudentId = this.StudentId
        };
    }
}
