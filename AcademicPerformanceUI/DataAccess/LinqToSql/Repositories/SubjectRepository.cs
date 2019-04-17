using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>
    {
        public SubjectRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
