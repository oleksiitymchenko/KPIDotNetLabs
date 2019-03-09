using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class StudentViewModel:BaseViewModel
    {
        private ObservableCollection<Student> _Students;
        private Student _SelectedStudent;

        public StudentViewModel()
        {
            _SelectedStudent = new Student();
            LoadData();
        }

        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => SetProperty(ref _SelectedStudent, value);
        }

        public ObservableCollection<Student> Students
        {
            get => _Students;
            set => SetProperty(ref _Students, value);
        }

        public void LoadData()
        {
            _Students = new ObservableCollection<Student>(ObjectLists.Students);
        }

        public void AddData()
        {
            var newStudent = new Student()
            {
                Id = Guid.NewGuid(),
                FirstName = _SelectedStudent.FirstName,
                LastName = _SelectedStudent.LastName,
                PhoneNumber = _SelectedStudent.PhoneNumber,
                Group = _SelectedStudent.Group
            };
            ObjectLists.Students.Add(newStudent);
            Students.Add(newStudent);
        }

        public void RemoveData()
        {
            ObjectLists.Students = ObjectLists.Students
                                            .Where(x => x.Id != _SelectedStudent.Id)
                                            .ToList();
            Students.Remove(SelectedStudent);
            SelectedStudent = new Student();
        }

        public void UpdateData()
        {
            var data = ObjectLists.Students.Find(o => o.Id == SelectedStudent.Id);
            data = new Student()
            {
                Id = _SelectedStudent.Id,
                FirstName = _SelectedStudent.FirstName,
                LastName = _SelectedStudent.LastName,
                PhoneNumber = _SelectedStudent.PhoneNumber,
                Group = _SelectedStudent.Group
            };
            var x = Students.ToList().Find(o => o.Id == SelectedStudent.Id);
            x = data;
        }
    }
}
