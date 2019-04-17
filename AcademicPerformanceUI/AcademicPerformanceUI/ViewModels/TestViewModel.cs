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
            SelectedEntity = new Test();
            LoadConnectedData();
        }
        
        public override void LoadConnectedData()
        {
            TeacherIds = new ObservableCollection<Guid>(UnitOfWork.TeacherRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
