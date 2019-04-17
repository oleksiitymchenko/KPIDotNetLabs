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

        public override Task<Test> CreateAsync(Test entity)
        {
            var sqltext = $"insert into [Test] (Id, Name, Theme, Date, TeacherId) " +
                 $"values('{entity.Id}', '{entity.Name}', '{entity.Theme}', '{entity.Date}', '{entity.TeacherId}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
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

        public override Task<Test> UpdateAsync(Test entity)
        {
            var sqltext = $"update [Test] set Name = '{entity.Name}', Theme = '{entity.Theme}', " +
                $"Date = '{entity.Date}', TeacherId = '{entity.TeacherId}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
