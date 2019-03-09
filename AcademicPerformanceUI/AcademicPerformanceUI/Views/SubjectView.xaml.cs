using AcademicPerformanceUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for SubjectView.xaml
    /// </summary>
    public partial class SubjectView : Page
    {
        private SubjectViewModel SubjectViewModel { get; set; }

        public SubjectView()
        {
            InitializeComponent();
            SubjectViewModel = new SubjectViewModel();
            DataContext = SubjectViewModel;
        }

        private void Add_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectViewModel.AddData();
        }

        private void Update_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectViewModel.UpdateData();
        }

        private void Remove_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectViewModel.RemoveData();
        }
    }
}
