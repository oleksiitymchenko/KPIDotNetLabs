using System;

namespace DataAccess.Models
{
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FinalTestType FinalTestType { get; set; }

        public double Hours { get; set; }
      
    }
}
