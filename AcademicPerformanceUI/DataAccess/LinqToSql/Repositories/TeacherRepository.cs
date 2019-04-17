using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
