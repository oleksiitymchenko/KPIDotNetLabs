using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
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

        private void Save_Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            TeacherViewModel.SaveEntity();
        }

        private void SaveAll__Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            TeacherViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                TeacherViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
