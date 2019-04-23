using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectInGroupRepository : BaseRepository<SubjectInGroup>
    {
        public SubjectInGroupRepository(string sqlConnection) : base(sqlConnection)
        {
        }

        public override Task<List<SubjectInGroup>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<SubjectInGroup>();
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
    }
}
