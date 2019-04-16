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
            SelectedEntity = new Student();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            //GroupIds = new ObservableCollection<Guid>(InMemoryLists.Groups.Select(o => o.Id));
        }
    }
}
