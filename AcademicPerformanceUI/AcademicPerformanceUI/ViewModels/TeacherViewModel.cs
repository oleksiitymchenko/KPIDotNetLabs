using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TeacherViewModel:BaseViewModel<Teacher>
    {
        private ObservableCollection<Teacher> _Teachers;
        private Teacher _SelectedTeacher;
        public ObservableCollection<Guid> SubjectIds { get; set; }

        public TeacherViewModel()
        {
            _SelectedTeacher = new Teacher();
            LoadData();
        }

        public Teacher SelectedTeacher
        {
            get => _SelectedTeacher;
            set => SetProperty(ref _SelectedTeacher, value);
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => _Teachers;
            set => SetProperty(ref _Teachers, value);
        }

        public void LoadData()
        {
            _Teachers = new ObservableCollection<Teacher>(InMemory.Teachers);
            SubjectIds = new ObservableCollection<Guid>(InMemory.Subjects.Select(o => o.Id));
        }

        public void AddData()
        {
            var newTeacher = new Teacher()
            {
                Id = Guid.NewGuid(),
                FirstName = _SelectedTeacher.FirstName,
                LastName = _SelectedTeacher.LastName,
                PhoneNumber = _SelectedTeacher.PhoneNumber,
                SubjectId = _SelectedTeacher.SubjectId
            };
            Teachers.Add(newTeacher);
            InMemory.Teachers.Add(newTeacher);
            Console.WriteLine(newTeacher.SubjectId);
            SelectedTeacher = new Teacher();

        }

        public void RemoveData()
        {
            InMemory.Teachers = InMemory.Teachers
                                            .Where(x => x.Id != _SelectedTeacher.Id)
                                            .ToList();
            Teachers.Remove(SelectedTeacher);
            SelectedTeacher = new Teacher();
        }

        public void UpdateData()
        {
            var data = InMemory.Teachers.Find(o => o.Id == SelectedTeacher.Id);
            data = new Teacher()
            {
                Id = _SelectedTeacher.Id,
                FirstName = _SelectedTeacher.FirstName,
                LastName = _SelectedTeacher.LastName,
                PhoneNumber = _SelectedTeacher.PhoneNumber,
                SubjectId = _SelectedTeacher.SubjectId
            };
            var x = Teachers.ToList().Find(o => o.Id == SelectedTeacher.Id);
            x = data;
        }
    }
}
