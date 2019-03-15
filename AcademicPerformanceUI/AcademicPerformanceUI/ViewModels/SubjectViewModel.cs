using DataAccess;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectViewModel:BaseViewModel<Subject>
    {
        public SubjectViewModel()
        {
            _SelectedEntity = new Subject();
            LoadData();
        }

        public override void LoadData()
        {
            _Entities = new ObservableCollection<Subject>(InMemory.Subjects);
        }
    }
}
