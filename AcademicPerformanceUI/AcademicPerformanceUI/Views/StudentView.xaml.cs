using AcademicPerformanceUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
