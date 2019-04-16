using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectInGroupRepository:GenericRepository<SubjectInGroup>
    {
        public SubjectInGroupRepository(string sqlConnection):base(sqlConnection)
        {

        }

        public override Task<SubjectInGroup> CreateAsync(SubjectInGroup entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
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
            return Task.FromResult(new List<SubjectInGroup>());
        }

        public override Task<SubjectInGroup> GetFirstOrDefaultAsync(Expression<Func<SubjectInGroup, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<SubjectInGroup> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<SubjectInGroup> UpdateAsync(SubjectInGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
