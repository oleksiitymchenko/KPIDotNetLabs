using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class GroupRepository:BaseRepository<Group>
    {
        public GroupRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
