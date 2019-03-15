namespace Services.Serialization
{
    public static class SerializationServiceFactory
    {
        public static ISerialization GetSerializationService()
        {
            return new XmlSerizalizationService();
        }
    }
}
