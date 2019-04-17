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

        public override Task<TestResult> CreateAsync(TestResult entity)
        {
            var sqltext = $"insert into [TestResult] (Id, Mark, StudentId, TestId) " +
                 $"values('{entity.Id}', '{entity.Mark}', '{entity.StudentId}', '{entity.TestId}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
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

        public override Task<TestResult> UpdateAsync(TestResult entity)
        {
            var sqltext = $"update [TestResult] set Mark = '{entity.Mark}', StudentId = '{entity.StudentId}', " +
               $"TestId = '{entity.TestId}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
