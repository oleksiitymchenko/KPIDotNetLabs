using System;

namespace DataAccess.Models
{
    public class Subject : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FinalTestType FinalTestType { get; set; }

        private double hours;
        public double Hours
        {
            get => hours;
            set
            {
                hours = hours > 0 ? hours : throw new FormatException("Hours of subject should be more than zero"); 
            }
        }
    }
}
