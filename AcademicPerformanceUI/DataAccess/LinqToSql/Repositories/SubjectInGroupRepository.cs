using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class SubjectInGroupRepository : BaseRepository<SubjectInGroup>
    {
        public SubjectInGroupRepository(string sqlConnection) : base(sqlConnection)
        {
        }
    }
}
