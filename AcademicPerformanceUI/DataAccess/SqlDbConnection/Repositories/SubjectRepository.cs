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
        public SubjectRepository(string sqlConnection):base(sqlConnection)
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
            var text = SqlHelper.GetAllSqlText<Subject>();
            var reader = ExecuteReader(text);
            var list = new List<Subject>();
            while (reader.Read())
            {
                list.Add(new Subject()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Hours = (int)reader["Hours"],
                    FinalTestType = (FinalTestType)reader["FinalTestType"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
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
