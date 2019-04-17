using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectInGroupViewModel:BaseViewModel<SubjectInGroup>
    {
        public ObservableCollection<Guid> SubjectIds { get; set; }
        public ObservableCollection<Guid> GroupsIds { get; set; }

        public SubjectInGroupViewModel()
        {
            SelectedEntity = new SubjectInGroup();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            SubjectIds = new ObservableCollection<Guid>(UnitOfWork.SubjectRepostitory.GetAllEntitiesAsync().Result.Select(o => o.Id));
            GroupsIds = new ObservableCollection<Guid>(UnitOfWork.GroupRepository.GetAllEntitiesAsync().Result.Select(o => o.Id));
        }
    }
}
