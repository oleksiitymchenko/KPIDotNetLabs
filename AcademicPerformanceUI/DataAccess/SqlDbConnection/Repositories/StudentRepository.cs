using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<Student> CreateAsync(Student entity)
        {
            var sqltext = $"insert into [Student] (Id, FirstName, LastName, PhoneNumber, GroupId) " +
                $"values('{entity.Id}', '{entity.FirstName}', '{entity.LastName}', '{entity.PhoneNumber}', '{entity.GroupId}')";
            var result  = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }


        public override Task<Student> UpdateAsync(Student entity)
        {
            var sqltext = $"update [Student] set FirstName = '{entity.FirstName}', LastName = '{entity.LastName}', " +
                $"PhoneNumber = '{entity.PhoneNumber}', GroupId = '{entity.GroupId}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<List<Student>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Student>();
            var reader = ExecuteReader(text);
            var list = new List<Student>();
            while (reader.Read())
            {
                list.Add(new Student()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    GroupId = (Guid)reader["GroupId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
