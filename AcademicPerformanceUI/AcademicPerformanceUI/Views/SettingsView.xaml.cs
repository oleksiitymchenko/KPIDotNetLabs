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
        public string SerializationTypeName { get; set; }

        private void ReloadType()
        {
            this.SerializationTypeName = SettingList.GetSerializationType.ToString();
        }

        public SettingsView()
        {
            InitializeComponent();
            ReloadType();
        }

        private void Button_Click_Xml(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.Xml;
            ReloadType();
        }

        private void Button_Click_Json(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.Json;
            ReloadType();
        }

        private void Button_Click_DataContract(object sender, RoutedEventArgs e)
        {
            SettingList.GetSerializationType = SerializationType.DataContract;
            ReloadType();
        }
    }
}
