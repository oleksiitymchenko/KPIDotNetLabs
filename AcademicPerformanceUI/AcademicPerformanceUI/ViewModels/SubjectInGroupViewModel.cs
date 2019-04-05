using DataAccess;
using DataAccess.InMemoryDb;
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
            _SelectedEntity = new SubjectInGroup();
            LoadData();
        }

        public override void LoadData()
        {
            _Entities = new ObservableCollection<SubjectInGroup>(InMemory.SubjectInGroups);
            SubjectIds = new ObservableCollection<Guid>(InMemory.Subjects.Select(o => o.Id));
            GroupsIds = new ObservableCollection<Guid>(InMemory.Groups.Select(o => o.Id));
        }
    }
}
