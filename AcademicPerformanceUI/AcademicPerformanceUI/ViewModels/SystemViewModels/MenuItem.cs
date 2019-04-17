using DataAccess.Models;
using System;
using System.Windows.Input;

namespace AcademicPerformanceUI.ViewModels
{
    public class MenuItem : BaseViewModel<Student>
    {
        private object _icon;
        private string _text;
        private bool _isEnabled = true;
        private DelegateCommand _command;
        private Uri _navigationDestination;

        public object Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, (DelegateCommand)value);
        }

        public Uri NavigationDestination
        {
            get => _navigationDestination;
            set => SetProperty(ref _navigationDestination, value);
        }

        public bool IsNavigation => _navigationDestination != null;

        public override void LoadConnectedData()
        {
            throw new NotImplementedException();
        }
    }
}
