using DataAccess.InMemoryDb;
using DataAccess.SqlDbConnection;
using DataAccess.Interfaces;
using Services.Settings;
using System;
using DataAccess.LinqToSql;

namespace Services
{
    public static class UnitOfWorkFactory
    {
        private static Lazy<SqlDbConnectionUnitOfWork> SqlDbConnectionUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork(SettingList.GetConnectionString));
        private static Lazy<LinqToSqlUnitOfWork> LinqToSqlUnitOfWorkInstance = new Lazy<LinqToSqlUnitOfWork>(()=> new LinqToSqlUnitOfWork(SettingList.GetConnectionString));
        private static Lazy<InMemoryUnitOfWork> InMemoryUnitOfWorkInstance = new Lazy<InMemoryUnitOfWork>(()=> new InMemoryUnitOfWork());

        public static IUnitOfWork GetUnitOfWork()
        {
            var type = SettingList.GetDataProvider;
            switch (type)
            {
                case DataProvider.InMemory: return InMemoryUnitOfWorkInstance.Value;
                case DataProvider.SqlDbConnection: return SqlDbConnectionUnitOfWorkInstance.Value;
                case DataProvider.LinqToSql: return LinqToSqlUnitOfWorkInstance.Value;
                default: return null;
            }
        }
    }
}
