using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicPerformanceUI.ViewModels
{
    public class TeacherViewModel:BaseViewModel
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
            _Teachers = new ObservableCollection<Teacher>(ObjectLists.Teachers);
        }

        public void AddData()
        {
            var newTeacher = new Teacher()
            {
                Id = Guid.NewGuid(),
                FirstName = _SelectedTeacher.FirstName,
                LastName = _SelectedTeacher.LastName,
                PhoneNumber = _SelectedTeacher.PhoneNumber,
                Subject = _SelectedTeacher.Subject
            };
            ObjectLists.Teachers.Add(newTeacher);
            Teachers.Add(newTeacher);
        }

        public void RemoveData()
        {
            ObjectLists.Teachers = ObjectLists.Teachers
                                            .Where(x => x.Id != _SelectedTeacher.Id)
                                            .ToList();
            Teachers.Remove(SelectedTeacher);
            SelectedTeacher = new Teacher();
        }

        public void UpdateData()
        {
            var data = ObjectLists.Teachers.Find(o => o.Id == SelectedTeacher.Id);
            data = new Teacher()
            {
                Id = _SelectedTeacher.Id,
                FirstName = _SelectedTeacher.FirstName,
                LastName = _SelectedTeacher.LastName,
                PhoneNumber = _SelectedTeacher.PhoneNumber,
                Subject = _SelectedTeacher.Subject
            };
            var x = Teachers.ToList().Find(o => o.Id == SelectedTeacher.Id);
            x = data;
        }
    }
}
