using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        protected string ConnectionString;
        protected SqlDbConnectionHelper SqlHelper;

        public GenericRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.SqlHelper = new SqlDbConnectionHelper();
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<Test>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<Group>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<Student>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<Subject>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<SubjectInGroup>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<Teacher>());
            //ExecuteNonQuery(SqlHelper.CreateTableSqlText<TestResult>());
        }
        public abstract Task<TEntity> CreateAsync(TEntity entity);

        public abstract Task<bool> DeleteAsync(Guid Id);

        public abstract Task<List<TEntity>> GetAllEntitiesAsync();

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

        public abstract Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        public abstract Task<TEntity> UpdateAsync(TEntity entity);

        public abstract void ReplaceCollection(List<TEntity> entities);

        public TEntity CreateEmptyObject()
        {
            var type = typeof(TEntity).Name;
            IEntity newObject = null;
            switch (type)
            {
                case "Group": newObject = new Group(); break;
                case "Student": newObject = new Student(); break;
                case "Subject": newObject = new Subject(); break;
                case "Teacher": newObject = new Teacher(); break;
                case "Test": newObject = new Test(); break;
                case "SubjectInGroup": newObject = new SubjectInGroup(); break;
                case "TestResult": newObject = new TestResult(); break;
                default: throw new Exception("No such type");
            }
            return (TEntity)newObject;
        }


        public virtual int ExecuteNonQuery(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // StoredProcedure, Text
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    var result = cmd.ExecuteNonQuery();
                    conn.Close();

                    return result;
                }
            }
        }


        public virtual SqlDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);

            conn.Open();

            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
