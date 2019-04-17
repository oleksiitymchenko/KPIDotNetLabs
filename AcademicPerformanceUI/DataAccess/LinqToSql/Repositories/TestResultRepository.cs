using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class TestResultRepository:BaseRepository<TestResult>
    {
        public TestResultRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
