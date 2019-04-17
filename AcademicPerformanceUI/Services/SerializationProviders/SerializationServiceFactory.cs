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
                case SerializationType.Json: return new JsonSerializationService();
                case SerializationType.DataContract: return new DataContractSerializationService();
                default: return null;
            }
        }
    }
}
