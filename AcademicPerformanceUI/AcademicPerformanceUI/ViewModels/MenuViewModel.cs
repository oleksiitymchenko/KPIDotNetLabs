using System;
using System.Collections.ObjectModel;
using System.Linq;
using MahApps.Metro.IconPacks;

namespace AcademicPerformanceUI.ViewModels
{ 

    public class MenuViewModel
    {
        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        public MenuViewModel()
        {
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserFriendsSolid }, Text = "Groups", NavigationDestination = new Uri("Views/GroupView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid }, Text = "Students", NavigationDestination = new Uri("Views/StudentView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CoffeeSolid }, Text = "Subjects", NavigationDestination = new Uri("Views/SubjectView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSlashSolid }, Text = "Teachers", NavigationDestination = new Uri("Views/TeacherView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.MarkerSolid }, Text = "Tests", NavigationDestination = new Uri("Views/TestView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.MoonSolid }, Text = "Results", NavigationDestination = new Uri("Views/TestResultView.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.AngrySolid }, Text = "SubjectInGroup", NavigationDestination = new Uri("Views/SubjectInGroup.xaml", UriKind.RelativeOrAbsolute) });

            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid }, Text = "Settings", NavigationDestination = new Uri("Views/SettingsView.xaml", UriKind.RelativeOrAbsolute) });
        }

        public ObservableCollection<MenuItem> Menu => AppMenu;

        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

        public object GetItem(object uri)
        {
            return null == uri ? null : this.Menu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }

        public object GetOptionsItem(object uri)
        {
            return null == uri ? null : this.OptionsMenu.FirstOrDefault(m => m.NavigationDestination.Equals(uri));
        }
    }
}
