using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(SqlConnection sqlConnection):base(sqlConnection)
        {

        }

        public override Task<Student> CreateAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Student>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Student> GetFirstOrDefaultAsync(Expression<Func<Student, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void ReplaceCollection(List<Student> entities)
        {
            throw new NotImplementedException();
        }

        public override Task<Student> UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
