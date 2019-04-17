using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TestResultRepository:GenericRepository<TestResult>
    {
        public TestResultRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<TestResult> CreateAsync(TestResult entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<TestResult>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<TestResult>();
            var reader = ExecuteReader(text);
            var list = new List<TestResult>();
            while (reader.Read())
            {
                list.Add(new TestResult()
                {
                    Id = (Guid)reader["Id"],
                    Mark = (int)reader["Mark"],
                    StudentId = (Guid)reader["StudentId"],
                    TestId = (Guid)reader["Studentid"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }

        public override Task<TestResult> GetFirstOrDefaultAsync(Expression<Func<TestResult, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<TestResult> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<TestResult> UpdateAsync(TestResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
