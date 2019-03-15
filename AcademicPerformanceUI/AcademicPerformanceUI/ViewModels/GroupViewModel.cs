using System.Collections.ObjectModel;
using DataAccess;
using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class GroupViewModel:BaseViewModel<Group>
    {
        public GroupViewModel()
        {
            _SelectedEntity = new Group();
            LoadData();
        }

        public override void LoadData()
        {
           Entities = new ObservableCollection<Group>(InMemory.Groups);
        }
    }
}
