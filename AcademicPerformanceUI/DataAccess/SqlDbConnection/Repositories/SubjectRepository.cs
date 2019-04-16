using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(SqlConnection sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Subject> CreateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Subject>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Subject> GetFirstOrDefaultAsync(Expression<Func<Subject, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Subject> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Subject> UpdateAsync(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
