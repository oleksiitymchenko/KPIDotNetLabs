using System;

namespace DataAccess.Models
{
    public class Test : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime Date { get; set; }
        public FinalTestType FinalTestType { get; set; }

        private Guid TeacherId;
        public Teacher Teacher
        {
            get => ObjectLists.Teachers.Find(t => t.Id == TeacherId);
            set
            {
                TeacherId = ObjectLists.Teachers.Exists(t => t.Id == value.Id)
                    ? value.Id
                    : throw new FormatException("Teacher with specified Id not exists");
            }
        }
    }
}
