using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
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

        private void Save_Student_OnClick(object sender, RoutedEventArgs e)
        {
            StudentViewModel.SaveEntity();
        }

        private void SaveAll__Student_OnClick(object sender, RoutedEventArgs e)
        {
            StudentViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                StudentViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
