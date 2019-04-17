using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>
    {
        public TeacherRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Teacher> CreateAsync(Teacher entity)
        {
            var sqltext = $"insert into [Teacher] (Id, FirstName, LastName, PhoneNumber, SubjectId) " +
                 $"values('{entity.Id}', '{entity.FirstName}', '{entity.LastName}', '{entity.PhoneNumber}', '{entity.SubjectId}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<List<Teacher>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Teacher>();
            var reader = ExecuteReader(text);
            var list = new List<Teacher>();
            while (reader.Read())
            {
                list.Add(new Teacher()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    SubjectId = (Guid)reader["SubjectId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }

        public override Task<Teacher> UpdateAsync(Teacher entity)
        {
            var sqltext = $"update [Teacher] set FirstName = '{entity.FirstName}', LastName = '{entity.LastName}', " +
                $"PhoneNumber = '{entity.PhoneNumber}', SubjectId = '{entity.SubjectId}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
