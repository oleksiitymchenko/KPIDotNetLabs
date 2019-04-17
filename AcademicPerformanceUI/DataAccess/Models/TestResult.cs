using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using DataAccess.Interfaces;

namespace DataAccess.Models
{
    [Table(Name = "TestResult")]
    [Serializable]
    public class TestResult : IEntity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        [DataMember()]
        public Guid Id { get; set; }
        [Column]
        [DataMember()]
        public int Mark { get; set; }

        [Column]
        [DataMember()]
        public Guid TestId { get; set; }

        [Column]
        [DataMember()]
        public Guid StudentId { get; set; }


        public object Clone() => new TestResult()
        {
            Id = this.Id,
            Mark = this.Mark,
            TestId = this.TestId,
            StudentId = this.StudentId
        };

        public IEntity MapFrom(IEntity mapFrom)
        {
            var entity = (TestResult)mapFrom;
            this.Id = entity.Id;
            this.Mark = entity.Mark;
            this.TestId = entity.TestId;
            this.StudentId = entity.StudentId;

            return this;
        }
    }
}
