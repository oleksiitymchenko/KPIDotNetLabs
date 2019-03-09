using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectViewModel:BaseViewModel
    {
        private ObservableCollection<Subject> _Subjects;
        private Subject _SelectedSubject;

        public SubjectViewModel()
        {
            _SelectedSubject = new Subject();
            LoadData();
        }

        public Subject SelectedSubject
        {
            get => _SelectedSubject;
            set => SetProperty(ref _SelectedSubject, value);
        }

        public ObservableCollection<Subject> Subjects
        {
            get => _Subjects;
            set => SetProperty(ref _Subjects, value);
        }

        public void LoadData()
        {
            _Subjects = new ObservableCollection<Subject>(ObjectLists.Subjects);
        }

        public void AddData()
        {
            var newSubject = new Subject()
            {
               Id = Guid.NewGuid(),
               Hours = SelectedSubject.Hours,
               Name = SelectedSubject.Name,
               FinalTestType = SelectedSubject.FinalTestType
            };
            ObjectLists.Subjects.Add(newSubject);
            Subjects.Add(newSubject);
        }

        public void RemoveData()
        {
            ObjectLists.Subjects = ObjectLists.Subjects
                                            .Where(x => x.Id != _SelectedSubject.Id)
                                            .ToList();
            Subjects.Remove(SelectedSubject);
            SelectedSubject = new Subject();
        }

        public void UpdateData()
        {
            var data = ObjectLists.Subjects.Find(o => o.Id == SelectedSubject.Id);
            data = new Subject()
            {
                Id = _SelectedSubject.Id,
                Hours = SelectedSubject.Hours,
                Name = SelectedSubject.Name,
                FinalTestType = SelectedSubject.FinalTestType
            };
            var x = Subjects.ToList().Find(o => o.Id == SelectedSubject.Id);
            x = data;
        }
    }
}
