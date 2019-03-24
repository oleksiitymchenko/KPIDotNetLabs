using Services.Settings;

namespace Services.Serialization
{
    public static class SerializationServiceFactory
    {
        public static ISerialization GetSerializationService()
        {
            var type = SettingList.GetSerializationType;
            switch (type)
            {
                case SerializationType.Xml: return new XmlSerizalizationService();
                case SerializationType.Json: return new XmlSerizalizationService();
                case SerializationType.DataContract: return new XmlSerizalizationService();
                default: return null;
            }
        }
    }
}
