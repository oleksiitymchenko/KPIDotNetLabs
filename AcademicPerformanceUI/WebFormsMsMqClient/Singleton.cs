using DataAccess.SqlDbConnection;

namespace WebFormsMsMqClient
{
    public static class Singleton
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olexi\TestDb.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlDbConnectionUnitOfWork UnitOfWork = new SqlDbConnectionUnitOfWork(connectionString);
    }
}