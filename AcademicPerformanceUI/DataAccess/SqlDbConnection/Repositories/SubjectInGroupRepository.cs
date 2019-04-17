using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectInGroupRepository:BaseRepository<SubjectInGroup>
    {
        public SubjectInGroupRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<SubjectInGroup> CreateAsync(SubjectInGroup entity)
        {
            var sqltext = $"insert into [SubjectInGroup] (Id, GroupId, SubjectId) " +
               $"values('{entity.Id}', '{entity.GroupId}', '{entity.SubjectId}')";
            var result = ExecuteNonQuery(sqltext);
            return Task.FromResult(result == 0 ? null : entity);
        }

        public override Task<List<SubjectInGroup>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Student>();
            var reader = ExecuteReader(text);
            var list = new List<SubjectInGroup>();
            while (reader.Read())
            {
                list.Add(new SubjectInGroup()
                {
                    Id = (Guid)reader["Id"],
                    GroupId = (Guid)reader["GroupId"],
                    SubjectId = (Guid)reader["SubjectId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }

        public override Task<SubjectInGroup> UpdateAsync(SubjectInGroup entity)
        {
            var sqltext = $"update [SubjectInGroup] set GroupId = '{entity.GroupId}', SubjectId = '{entity.SubjectId}'";

            var result = ExecuteNonQuery(sqltext);

            return Task.FromResult(result == 0 ? null : entity);
        }
    }
}
