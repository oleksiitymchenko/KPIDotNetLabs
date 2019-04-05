using DataAccess.Models;

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
