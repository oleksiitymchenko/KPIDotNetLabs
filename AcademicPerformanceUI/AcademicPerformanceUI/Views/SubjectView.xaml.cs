using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
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

        private void Save_Subject_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectViewModel.SaveEntity();
        }

        private void SaveAll__Subject_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                SubjectViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
