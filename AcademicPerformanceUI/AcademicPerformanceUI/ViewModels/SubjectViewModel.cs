using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectViewModel:BaseViewModel<Subject>
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
            _Subjects = new ObservableCollection<Subject>(InMemory.Subjects);
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
            InMemory.Subjects.Add(newSubject);
            Subjects.Add(newSubject);
        }

        public void RemoveData()
        {
            InMemory.Subjects = InMemory.Subjects
                                            .Where(x => x.Id != _SelectedSubject.Id)
                                            .ToList();
            Subjects.Remove(SelectedSubject);
            SelectedSubject = new Subject();
        }

        public void UpdateData()
        {
            var data = InMemory.Subjects.Find(o => o.Id == SelectedSubject.Id);
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
