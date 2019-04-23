using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>
    {
        public SubjectRepository(string sqlConnection):base(sqlConnection)
        {
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
                    Hours = (double)reader["Hours"],
                    FinalTestType = ((FinalTestType)reader["FinalTestType"])
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
