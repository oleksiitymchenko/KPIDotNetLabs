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
        public SubjectInGroupRepository(SqlConnection sqlConnection):base(sqlConnection)
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
            throw new NotImplementedException();
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
