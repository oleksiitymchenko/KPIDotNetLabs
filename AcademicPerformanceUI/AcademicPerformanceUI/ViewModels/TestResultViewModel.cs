using DataAccess.InMemoryDb;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TestResultViewModel:BaseViewModel<TestResult>
    {
        public ObservableCollection<Guid> StudentIds { get; set; }
        public ObservableCollection<Guid> TestIds { get; set; }

        public TestResultViewModel()
        {
            SelectedEntity = new TestResult();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            TestIds = new ObservableCollection<Guid>(InMemory.Tests.Select(o => o.Id));
            StudentIds = new ObservableCollection<Guid>(InMemory.Students.Select(o => o.Id));
        }
    }
}
