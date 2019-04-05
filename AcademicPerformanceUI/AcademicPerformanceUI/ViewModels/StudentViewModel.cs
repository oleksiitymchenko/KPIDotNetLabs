using DataAccess;
using DataAccess.InMemoryDb;
using DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace AcademicPerformanceUI.ViewModels
{
    public class StudentViewModel:BaseViewModel<Student>
    {
        public ObservableCollection<Guid> GroupIds { get; set; }

        public StudentViewModel()
        {
            _SelectedEntity = new Student();
            LoadData();
        }

        public override void LoadData()
        {
            Entities = new ObservableCollection<Student>(InMemory.Students);
            GroupIds = new ObservableCollection<Guid>(InMemory.Groups.Select(o => o.Id));
        }
    }
}
