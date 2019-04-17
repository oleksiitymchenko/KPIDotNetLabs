using System;
using System.IO;
using System.Xml.Serialization;

namespace Services.Serialization
{
    public class XmlSerizalizationService: ISerialization
    {
        private XmlSerializer XmlSerializer;

        public virtual bool SerializeEntity<Entity>(Entity entity, string path)
        {
            path = path + ".xml";
            XmlSerializer = new XmlSerializer(typeof(Entity));
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer.Serialize(fs, entity);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public virtual Entity DeserizalizeEntity<Entity>(string path)
        {
            XmlSerializer = new XmlSerializer(typeof(Entity));
            Entity entity;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    entity = (Entity)XmlSerializer.Deserialize(fs);
                }
                return entity;
            }
            catch(Exception)
            {
                return default(Entity);
            }
        }
    }
}
