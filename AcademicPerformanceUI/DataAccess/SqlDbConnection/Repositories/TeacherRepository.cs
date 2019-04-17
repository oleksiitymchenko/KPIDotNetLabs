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
    }
}
