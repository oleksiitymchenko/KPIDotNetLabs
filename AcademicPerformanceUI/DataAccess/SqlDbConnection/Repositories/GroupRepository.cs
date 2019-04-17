using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class GroupRepository:BaseRepository<Group>
    {
        public GroupRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Group> CreateAsync(Group entity)
        {
            var sqltext = $"insert into [Group] (Id, GroupName, MaxStudents, PhoneNumber, StudyYear) " +
                $"values('{entity.Id}', '{entity.GroupName}', '{entity.MaxStudents}', '{entity.StudyYear}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<List<Group>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Group>();
            var reader = ExecuteReader(text);
            var list = new List<Group>();
            while (reader.Read())
            {
                list.Add(new Group()
                {
                    Id = (Guid)reader["Id"],
                    GroupName = reader["GroupName"].ToString(),
                    StudyYear = (int)reader["StudyYear"],
                    MaxStudents = (int)reader["MaxStudents"],
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }


        public override Task<Group> UpdateAsync(Group entity)
        {
            var sqltext = $"update [Group] set GroupName = '{entity.GroupName}', MaxStudents = '{entity.MaxStudents}', " +
                $"StudyYear = '{entity.StudyYear}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
