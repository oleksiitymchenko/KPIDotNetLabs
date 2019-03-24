namespace Services.Settings
{
    public static class SettingList
    {
        public static SerializationType GetSerializationType { get; set; } = SerializationType.Xml;
    }

    public enum SerializationType
    {
        Xml,
        Json,
        DataContract
    }
}
