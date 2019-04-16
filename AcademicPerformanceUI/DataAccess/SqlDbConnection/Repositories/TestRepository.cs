using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TestRepository:GenericRepository<Test>
    {
        public TestRepository(SqlConnection sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Test> CreateAsync(Test entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Test>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Test> GetFirstOrDefaultAsync(Expression<Func<Test, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Test> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Test> UpdateAsync(Test entity)
        {
            throw new NotImplementedException();
        }
    }
}
