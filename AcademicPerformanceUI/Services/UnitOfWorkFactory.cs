using DataAccess.InMemoryDb;
using DataAccess.Interfaces;
using Services.Settings;
using System;

namespace Services
{
    public static class UnitOfWorkFactory
    {
        private static Lazy<SqlDbConnectionUnitOfWork> SqlDbConnectionUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork());
        private static Lazy<SqlDbConnectionUnitOfWork> InMemoryUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork());
        private static Lazy<SqlDbConnectionUnitOfWork> LinqToSqlUnitOfWorkInstance = new Lazy<SqlDbConnectionUnitOfWork>(()=> new SqlDbConnectionUnitOfWork());

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
