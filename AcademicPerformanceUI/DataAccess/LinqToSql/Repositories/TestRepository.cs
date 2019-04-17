using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class TestRepository:BaseRepository<Test>
    {
        public TestRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
