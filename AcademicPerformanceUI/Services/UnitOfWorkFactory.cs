using DataAccess.InMemoryDb;
using DataAccess.SqlDbConnection;
using DataAccess.Interfaces;
using Services.Settings;
using System;

namespace Services
{
    public static class UnitOfWorkFactory
    {
        private static Lazy<SqlDbConnectionUnitOfWork> SqlDbConnectionUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork(SettingList.GetConnectionString));
        private static Lazy<SqlDbConnectionUnitOfWork> InMemoryUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork(SettingList.GetConnectionString));
        private static Lazy<InMemoryUnitOfWork> LinqToSqlUnitOfWorkInstance = new Lazy<InMemoryUnitOfWork>(()=> new InMemoryUnitOfWork());

        public static IUnitOfWork GetUnitOfWork()
        {
            var type = SettingList.GetDataProvider;
            switch (type)
            {
                case DataProvider.InMemory: return SqlDbConnectionUnitOfWorkInstance.Value;
                case DataProvider.SqlDbConnection: return SqlDbConnectionUnitOfWorkInstance.Value;
                case DataProvider.LinqToSql: return SqlDbConnectionUnitOfWorkInstance.Value;
                default: return null;
            }
        }
    }
}
