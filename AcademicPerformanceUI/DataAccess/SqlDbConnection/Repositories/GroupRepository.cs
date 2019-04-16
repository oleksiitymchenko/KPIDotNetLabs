using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class GroupRepository:GenericRepository<Group>
    {
        public GroupRepository(SqlConnection sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Group> CreateAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Group>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Group> GetFirstOrDefaultAsync(Expression<Func<Group, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Group> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Group> UpdateAsync(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
