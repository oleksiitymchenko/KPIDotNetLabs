using AcademicPerformanceUI.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using DataAccess.Interfaces;

namespace AcademicPerformanceUI.Views
{
    public class BaseView<Entity>:Page where Entity :IEntity
    {
        public BaseViewModel<Entity> BaseViewModel { get; set; }

        public BaseView(BaseViewModel<Entity> baseViewModel)
        {
            BaseViewModel = baseViewModel;
        }

        public void Upload_EntityList_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                BaseViewModel.DeserializeList(fileDialog.FileName);
            }
        }
    }
}
