using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>
    {
        public TeacherRepository(SqlConnection sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Teacher> CreateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Teacher>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Teacher> GetFirstOrDefaultAsync(Expression<Func<Teacher, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Teacher> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Teacher> UpdateAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
