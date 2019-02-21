using System;

namespace DataAccess.Models
{
    public class Group : IEntity
    {
        public Guid Id { get; set; }
        public string FacultyName { get; set; }

        private int maxStudents;
        public int MaxStudents
        {
            get => maxStudents;
            set
            {
                maxStudents = value > 0 ? value : throw new FormatException("Amount of students should be more than zero");
            }
        }

        private int studyYear;
        public int StudyYear
        {
            get => studyYear;
            set
            {
                studyYear = value > 0 ? value : throw new FormatException("Amount of students should be more than zero");
            }
        }
    }
}
