using System;

namespace DataAccess.Models
{
    [Serializable]
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FinalTestType FinalTestType { get; set; }
        public double Hours { get; set; }

        public object Clone() => new Subject()
        {
            Id = this.Id,
            Name = this.Name,
            FinalTestType = this.FinalTestType,
            Hours = this.Hours
        };
    }
}
