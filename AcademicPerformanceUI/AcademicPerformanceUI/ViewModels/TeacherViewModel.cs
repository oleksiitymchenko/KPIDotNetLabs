using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class TeacherViewModel:BaseViewModel<Teacher>
    {
        public ObservableCollection<Guid> SubjectIds { get; set; }

        public TeacherViewModel()
        {
            SelectedEntity = new Teacher();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
           SubjectIds = new ObservableCollection<Guid>(UnitOfWork.SubjectRepostitory.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
