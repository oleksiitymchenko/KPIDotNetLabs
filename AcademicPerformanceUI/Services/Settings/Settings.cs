namespace Services.Settings
{
    public static class SettingList
    {
        public static SerializationType GetSerializationType { get; set; } = SerializationType.Xml;
        public static DataProvider GetDataProvider { get; set; } = DataProvider.InMemory;
    }

    public enum SerializationType
    {
        Xml,
        Json,
        DataContract
    }

    public enum DataProvider
    {
        InMemory,
        SqlDbConnection,
        LinqToSql
    }
}
