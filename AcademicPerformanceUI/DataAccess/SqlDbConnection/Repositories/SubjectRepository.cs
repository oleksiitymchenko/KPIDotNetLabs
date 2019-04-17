using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>
    {
        public SubjectRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Subject> CreateAsync(Subject entity)
        {
            var sqltext = $"insert into [Subject] (Id, Name, Hours, FinalTestType) " +
                 $"values('{entity.Id}', '{entity.Name}', '{entity.Hours}', '{entity.FinalTestType}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<List<Subject>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Subject>();
            var reader = ExecuteReader(text);
            var list = new List<Subject>();
            while (reader.Read())
            {
                list.Add(new Subject()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Hours = (int)reader["Hours"],
                    FinalTestType = (FinalTestType)reader["FinalTestType"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }

        public override Task<Subject> UpdateAsync(Subject entity)
        {
            var sqltext = $"update [Subject] set Name = '{entity.Name}', Hours = '{entity.Hours}', " +
                $"FinalTestType = '{entity.FinalTestType}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
