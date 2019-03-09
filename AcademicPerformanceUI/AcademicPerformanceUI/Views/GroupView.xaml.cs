using AcademicPerformanceUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class GroupView : Page
    {
        private GroupViewModel GroupViewModel { get; set; }

        public GroupView()
        {
            InitializeComponent();
            GroupViewModel = new GroupViewModel();
            DataContext = GroupViewModel;
        }

        private void Add_Group_OnClick(object sender, RoutedEventArgs e)
        {
            GroupViewModel.AddData();
        }

        private void Update_DriverShift_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Remove_Group_OnClick(object sender, RoutedEventArgs e)
        {
            GroupViewModel.RemoveData();
        }
    }
}
