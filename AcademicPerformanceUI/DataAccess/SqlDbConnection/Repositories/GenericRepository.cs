using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected SqlConnection SqlConnection;

        public GenericRepository(SqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
        }
        public abstract Task<TEntity> CreateAsync(TEntity entity);

        public abstract Task<bool> DeleteAsync(Guid Id);

        public abstract Task<List<TEntity>> GetAllEntitiesAsync();

        public abstract Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        public abstract Task<TEntity> UpdateAsync(TEntity entity);

        public abstract void ReplaceCollection(List<TEntity> entities);

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity);
            IEntity newObject = null;
            if (type == typeof(Group)) newObject = new Group();
            if (type == typeof(Student)) newObject = new Student();
            if (type == typeof(Subject)) newObject = new Subject();
            if (type == typeof(Teacher)) newObject = new Teacher();
            if (type == typeof(Test)) newObject = new Test();
            if (type == typeof(SubjectInGroup)) newObject = new SubjectInGroup();
            if (type == typeof(TestResult)) newObject = new TestResult();
            return (TEntity)newObject;
        }
    }
}
