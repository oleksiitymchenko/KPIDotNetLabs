using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class GroupViewModel:BaseViewModel<Group>
    {
        public GroupViewModel()
        {
            LoadConnectedData();
        }

        public override void LoadConnectedData()
        {
            SelectedEntity = new Group();
        }
    }
}
