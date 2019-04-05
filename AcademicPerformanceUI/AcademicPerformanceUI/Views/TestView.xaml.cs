using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : Page
    {
        private TestViewModel TestViewModel { get; set; }

        public TestView()
        {
            InitializeComponent();
            TestViewModel = new TestViewModel();
            DataContext = TestViewModel;
        }

        private void Add_Test_OnClick(object sender, RoutedEventArgs e)
        {
            TestViewModel.AddData();
        }

        private void Update_Test_OnClick(object sender, RoutedEventArgs e)
        {
            TestViewModel.UpdateData();
        }

        private void Remove_Test_OnClick(object sender, RoutedEventArgs e)
        {
            TestViewModel.RemoveData();
        }

        private void Save_Test_OnClick(object sender, RoutedEventArgs e)
        {
            TestViewModel.SaveEntity();
        }

        private void SaveAll__Test_OnClick(object sender, RoutedEventArgs e)
        {
            TestViewModel.SaveAllEntities();
        }


        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                TestViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
