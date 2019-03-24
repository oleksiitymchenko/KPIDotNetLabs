using Services.Settings;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformanceUI.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public SerializationType SerializationType { get; set; }

        public SettingsView()
        {
            this.SerializationType = SettingList.GetSerializationType;
            InitializeComponent();
        }

        private void Button_Click_Xml(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.Xml;
        }

        private void Button_Click_Json(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.Xml;
        }

        private void Button_Click_DataContract(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.Xml;
        }
    }
}
