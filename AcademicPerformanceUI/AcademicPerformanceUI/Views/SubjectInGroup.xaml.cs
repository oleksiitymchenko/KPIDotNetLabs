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
    /// Interaction logic for SubjectInGroup.xaml
    /// </summary>
    public partial class SubjectInGroupView : Page
    {
        private SubjectInGroupViewModel SubjectInGroupViewModel { get; set; }

        public SubjectInGroupView()
        {
            InitializeComponent();
            SubjectInGroupViewModel = new SubjectInGroupViewModel();
            DataContext = SubjectInGroupViewModel;
        }

        private void Add_SubjectInGroup_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectInGroupViewModel.AddData();
        }

        private void Update_SubjectInGroup_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectInGroupViewModel.UpdateData();
        }

        private void Remove_SubjectInGroup_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectInGroupViewModel.RemoveData();
        }
    }
}
