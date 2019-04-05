using DataAccess;
using DataAccess.Models;
using System.Collections.ObjectModel;

namespace AcademicPerformanceUI.ViewModels
{
    public class SubjectViewModel:BaseViewModel<Subject>
    {
        public SubjectViewModel()
        {
            SelectedEntity = new Subject();
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
        }
    }
}
