using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectInGroupViewModel:BaseViewModel<SubjectInGroup>
    {
        private ObservableCollection<SubjectInGroup> _SubjectInGroups;
        private SubjectInGroup _SelectedSubjectInGroup;
        public ObservableCollection<Guid> SubjectIds { get; set; }
        public ObservableCollection<Guid> GroupsIds { get; set; }

        public SubjectInGroupViewModel()
        {
            _SelectedSubjectInGroup = new SubjectInGroup();
            LoadData();
        }

        public SubjectInGroup SelectedSubjectInGroup
        {
            get => _SelectedSubjectInGroup;
            set => SetProperty(ref _SelectedSubjectInGroup, value);
        }

        public ObservableCollection<SubjectInGroup> SubjectInGroups
        {
            get => _SubjectInGroups;
            set => SetProperty(ref _SubjectInGroups, value);
        }

        public void LoadData()
        {
            _SubjectInGroups = new ObservableCollection<SubjectInGroup>(InMemory.SubjectInGroups);
            SubjectIds = new ObservableCollection<Guid>(InMemory.Subjects.Select(o => o.Id));
            GroupsIds = new ObservableCollection<Guid>(InMemory.Groups.Select(o => o.Id));
        }

        public void AddData()
        {
            var newSubjectInGroup = new SubjectInGroup()
            {
                Id = Guid.NewGuid(),
                GroupId = SelectedSubjectInGroup.GroupId,
                SubjectId = SelectedSubjectInGroup.SubjectId
            };
            InMemory.SubjectInGroups.Add(newSubjectInGroup);
            SubjectInGroups.Add(newSubjectInGroup);
        }

        public void RemoveData()
        {
            InMemory.SubjectInGroups = InMemory.SubjectInGroups
                                            .Where(x => x.Id != _SelectedSubjectInGroup.Id)
                                            .ToList();
            SubjectInGroups.Remove(SelectedSubjectInGroup);
            SelectedSubjectInGroup = new SubjectInGroup();
        }

        public void UpdateData()
        {
            var data = InMemory.SubjectInGroups.Find(o => o.Id == SelectedSubjectInGroup.Id);
            data = new SubjectInGroup()
            {
                Id = _SelectedSubjectInGroup.Id,
                GroupId = SelectedSubjectInGroup.GroupId,
                SubjectId = SelectedSubjectInGroup.SubjectId
            };
            var x = SubjectInGroups.ToList().Find(o => o.Id == SelectedSubjectInGroup.Id);
            x = data;
        }
    }
}
