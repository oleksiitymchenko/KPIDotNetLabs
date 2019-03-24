using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Services.Serialization
{
    public class DataContractSerializationService : ISerialization
    {
        public Entity DeserizalizeEntity<Entity>(string path)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Entity));
            Entity entity;
            try
            {
                FileStream fs = new FileStream(path,FileMode.Open);
                var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

                entity = (Entity)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                return entity;
            }
            catch (Exception)
            {
                return default(Entity);
            }
    }

        public bool SerializeEntity<Entity>(Entity entity, string path)
        {
            path = path + ".xml";
            var ser = new DataContractSerializer(typeof(Entity));
            try
            {
                var writer = new FileStream(path, FileMode.Create);

                ser.WriteObject(writer, entity);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
