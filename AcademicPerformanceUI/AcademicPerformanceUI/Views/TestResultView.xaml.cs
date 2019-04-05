using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for TestResultResultView.xaml
    /// </summary>
    public partial class TestResultView : Page
    {

        private TestResultViewModel TestResultViewModel { get; set; }

        public TestResultView()
        {
            InitializeComponent();
            TestResultViewModel = new TestResultViewModel();
            DataContext = TestResultViewModel;
        }

        private void Add_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TestResultViewModel.AddData();
        }

        private void Update_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TestResultViewModel.UpdateData();
        }

        private void Remove_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TestResultViewModel.RemoveData();
        }

        private void Save_TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TestResultViewModel.SaveEntity();
        }

        private void SaveAll__TestResult_OnClick(object sender, RoutedEventArgs e)
        {
            TestResultViewModel.SaveAllEntities();
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                TestResultViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
