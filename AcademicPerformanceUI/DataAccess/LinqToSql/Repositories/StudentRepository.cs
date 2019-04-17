using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
