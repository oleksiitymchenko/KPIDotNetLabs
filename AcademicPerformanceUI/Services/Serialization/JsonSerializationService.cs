using Newtonsoft.Json;
using System;
using System.IO;

namespace Services.Serialization
{
    public class JsonSerializationService: ISerialization
    {
        public Entity DeserizalizeEntity<Entity>(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            Entity entity;
            try
            {
                using (StreamReader file = File.OpenText(path))
                {
                    entity = (Entity)serializer.Deserialize(file, typeof(Entity));
                }
                return entity;
            }
            catch (Exception)
            {
                return default(Entity);
            }
        }

        public bool SerializeEntity<Entity>(Entity entity, string path)
        {
            path = path + ".json";
            var serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
