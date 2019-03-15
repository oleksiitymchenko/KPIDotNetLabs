using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TestViewModel: BaseViewModel<Test>
    {
        public ObservableCollection<Guid> TeacherIds { get; set; }

        public TestViewModel()
        {
            _SelectedEntity = new Test();
            LoadData();
        }
        
        public override void LoadData()
        {
            _Entities = new ObservableCollection<Test>(InMemory.Tests);
            TeacherIds = new ObservableCollection<Guid>(InMemory.Teachers.Select(o => o.Id));
        }
    }
}
