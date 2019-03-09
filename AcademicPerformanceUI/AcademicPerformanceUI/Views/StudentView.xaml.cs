using AcademicPerformanceUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Page
    {
        private StudentViewModel StudentViewModel { get; set; }

        public StudentView()
        {
            InitializeComponent();
            StudentViewModel = new StudentViewModel();
            DataContext = StudentViewModel;
        }

        private void Add_Student_OnClick(object sender, RoutedEventArgs e)
        {
            StudentViewModel.AddData();
        }

        private void Update_Student_OnClick(object sender, RoutedEventArgs e)
        {
            StudentViewModel.UpdateData();
        }

        private void Remove_Student_OnClick(object sender, RoutedEventArgs e)
        {
            StudentViewModel.RemoveData();
        }
    }
}
