using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TestViewModel: BaseViewModel<Test>
    {
        private ObservableCollection<Test> _Tests;
        private Test _SelectedTest;
        public ObservableCollection<Guid> TeacherIds { get; set; }

        public TestViewModel()
        {
            _SelectedTest = new Test();
            LoadData();
        }

        public Test SelectedTest
        {
            get => _SelectedTest;
            set => SetProperty(ref _SelectedTest, value);
        }

        public ObservableCollection<Test> Tests
        {
            get => _Tests;
            set => SetProperty(ref _Tests, value);
        }

        public void LoadData()
        {
            _Tests = new ObservableCollection<Test>(InMemory.Tests);
            TeacherIds = new ObservableCollection<Guid>(InMemory.Teachers.Select(o => o.Id));
        }

        public void AddData()
        {
            var newTest = new Test()
            {
                Id = Guid.NewGuid(),
                Name = _SelectedTest.Name,
                Theme = _SelectedTest.Theme,
                TeacherId = _SelectedTest.TeacherId,
                Date = _SelectedTest.Date
            };
            InMemory.Tests.Add(newTest);
            Tests.Add(newTest);
        }

        public void RemoveData()
        {
            InMemory.Tests = InMemory.Tests
                                            .Where(x => x.Id != _SelectedTest.Id)
                                            .ToList();
            Tests.Remove(SelectedTest);
            SelectedTest = new Test();
        }

        public void UpdateData()
        {
            var data = InMemory.Tests.Find(o => o.Id == SelectedTest.Id);
            data = new Test()
            {
                Id = _SelectedTest.Id,
                Name = _SelectedTest.Name,
                Theme = _SelectedTest.Theme,
                TeacherId = _SelectedTest.TeacherId,
                Date = _SelectedTest.Date
            };
            var x = Tests.ToList().Find(o => o.Id == SelectedTest.Id);
            x = data;
        }
        
    }
}
