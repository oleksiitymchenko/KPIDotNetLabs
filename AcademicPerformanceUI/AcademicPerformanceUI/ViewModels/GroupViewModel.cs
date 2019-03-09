using System;
using System.Collections.ObjectModel;
using DataAccess;
using System.Linq;
using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class GroupViewModel:BaseViewModel
    {
        private ObservableCollection<Group> _Groups;
        private Group _SelectedGroup;

        public GroupViewModel()
        {
            _SelectedGroup = new Group();
            LoadData();
        }

        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => SetProperty(ref _SelectedGroup, value);
        }

        public ObservableCollection<Group> DriverShifts
        {
            get => _Groups;
            set => SetProperty(ref _Groups, value);
        }

        public void LoadData()
        {
           _Groups = new ObservableCollection<Group>(ObjectLists.Groups);
        }

        public void AddData()
        {
            var newGroup = new Group() {
                Id = Guid.NewGuid(),
                GroupName = _SelectedGroup.GroupName,
                StudyYear = _SelectedGroup.StudyYear,
                MaxStudents = _SelectedGroup.MaxStudents
            };
            ObjectLists.Groups.Add(newGroup);
        }

        public void RemoveData()
        {
            ObjectLists.Groups = ObjectLists.Groups
                                            .Where(x => x.Id != _SelectedGroup.Id)
                                            .ToList();
            DriverShifts.Remove(SelectedGroup);
            SelectedGroup = new Group();
        }
    }
}
