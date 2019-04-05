using System.Collections.ObjectModel;
using DataAccess;
using DataAccess.InMemoryDb;
using DataAccess.Models;

namespace AcademicPerformanceUI.ViewModels
{
    public class GroupViewModel:BaseViewModel<Group>
    {
        public GroupViewModel()
        {
            LoadData();
        }

        public override void LoadData()
        {
            _SelectedEntity = new Group();
            Entities = new ObservableCollection<Group>(InMemory.Groups);
        }
    }
}
