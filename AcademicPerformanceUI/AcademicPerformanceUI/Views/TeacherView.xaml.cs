using AcademicPerformanceUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Page
    {
        private TeacherViewModel TeacherViewModel { get; set; }

        public TeacherView()
        {
            InitializeComponent();
            TeacherViewModel = new TeacherViewModel();
            DataContext = TeacherViewModel;
        }

        private void Add_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            TeacherViewModel.AddData();
        }

        private void Update_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            TeacherViewModel.UpdateData();
        }

        private void Remove_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            TeacherViewModel.RemoveData();
        }
    }
}
