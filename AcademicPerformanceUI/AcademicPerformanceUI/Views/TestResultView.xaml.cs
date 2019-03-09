using AcademicPerformanceUI.ViewModels;
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
    }
}
