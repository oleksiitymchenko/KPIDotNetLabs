using DataAccess;
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
            _SelectedEntity = new Teacher();
            LoadData();
        }

        public override void LoadData()
        {
            _Entities = new ObservableCollection<Teacher>(InMemory.Teachers);
            SubjectIds = new ObservableCollection<Guid>(InMemory.Subjects.Select(o => o.Id));
        }
    }
}
