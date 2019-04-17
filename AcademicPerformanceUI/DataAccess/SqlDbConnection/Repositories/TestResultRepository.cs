using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TestResultRepository:BaseRepository<TestResult>
    {
        public TestResultRepository(string sqlConnection):base(sqlConnection)
        {
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
    }
}
