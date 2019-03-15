using DataAccess.Models;

namespace Services.Serialization
{
    public interface ISerialization
    {
        bool SerializeEntity<Entity>(IEntity entity, string path);
        Entity DeserizalizeEntity<Entity>(string path);
    }
}
