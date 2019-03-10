using System;

namespace DataAccess.Models
{
    public class TestResult:IEntity
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }

        public Guid TestId { get; set; }
        public Test Test
        {
            get => InMemory.Tests.Find(o => o.Id == TestId);
        }

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
