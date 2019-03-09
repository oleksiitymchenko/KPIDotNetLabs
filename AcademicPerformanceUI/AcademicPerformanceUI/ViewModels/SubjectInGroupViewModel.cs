using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectInGroupViewModel:BaseViewModel
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
            _SubjectInGroups = new ObservableCollection<SubjectInGroup>(ObjectLists.SubjectInGroups);
            SubjectIds = new ObservableCollection<Guid>(ObjectLists.Subjects.Select(o => o.Id));
            GroupsIds = new ObservableCollection<Guid>(ObjectLists.Groups.Select(o => o.Id));
        }

        public void AddData()
        {
            var newSubjectInGroup = new SubjectInGroup()
            {
                Id = Guid.NewGuid(),
                GroupId = SelectedSubjectInGroup.GroupId,
                SubjectId = SelectedSubjectInGroup.SubjectId
            };
            ObjectLists.SubjectInGroups.Add(newSubjectInGroup);
            SubjectInGroups.Add(newSubjectInGroup);
        }

        public void RemoveData()
        {
            ObjectLists.SubjectInGroups = ObjectLists.SubjectInGroups
                                            .Where(x => x.Id != _SelectedSubjectInGroup.Id)
                                            .ToList();
            SubjectInGroups.Remove(SelectedSubjectInGroup);
            SelectedSubjectInGroup = new SubjectInGroup();
        }

        public void UpdateData()
        {
            var data = ObjectLists.SubjectInGroups.Find(o => o.Id == SelectedSubjectInGroup.Id);
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
