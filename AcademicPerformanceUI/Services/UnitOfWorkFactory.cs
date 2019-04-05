using DataAccess.Interfaces;
using DataAccess.SqlDbConnection;
using Services.Settings;

namespace Services
{
    public static class UnitOfWorkFactory
    {
        public static IUnitOfWork GetUnitOfWork()
        {
            var type = SettingList.GetDataProvider;
            switch (type)
            {
                case DataProvider.InMemory: return new InMemoryUnitOfWork();
                case DataProvider.SqlDbConnection: return new InMemoryUnitOfWork();
                case DataProvider.LinqToSql: return new InMemoryUnitOfWork();
                default: return null;
            }
        }
    }
}
