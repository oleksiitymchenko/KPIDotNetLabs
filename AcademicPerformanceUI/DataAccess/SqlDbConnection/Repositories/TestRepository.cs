using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TestRepository:BaseRepository<Test>
    {
        public TestRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Test>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Test>();
            var reader = ExecuteReader(text);
            var list = new List<Test>();
            while (reader.Read())
            {
                list.Add(new Test()
                {
                    Id = (Guid)reader["Id"],
                    Theme = reader["Theme"].ToString(),
                    Name = reader["Name"].ToString(),
                    Date = (DateTime)reader["Date"],
                    TeacherId = (Guid)reader["TeacherId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
