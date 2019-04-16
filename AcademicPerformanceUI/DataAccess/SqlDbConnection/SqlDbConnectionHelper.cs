using DataAccess.Interfaces;
using System;
using System.Text;

namespace DataAccess.SqlDbConnection
{
    public class SqlDbConnectionHelper
    {
        public string CreateTableSqlText<Entity>()where Entity : IEntity
        {
            var sqltext = new StringBuilder();
            sqltext.Append("create table ");

            var tableName = typeof(Entity).Name;

            sqltext.Append($"[{tableName}]");
            sqltext.Append("(");
            var fields = typeof(Entity).GetProperties();

            foreach (var field in fields)
            {
                sqltext.Append($" {field.Name}");

                switch (field.PropertyType.Name)
                {
                    case "Guid": sqltext.Append($" uniqueidentifier,"); break;
                    case "String": sqltext.Append($" varchar(max),"); break;
                    case "Int32": sqltext.Append($" int,"); break;
                    case "Int64": sqltext.Append($" int,"); break;
                    case "Double": sqltext.Append($" real,"); break;
                    case "DateTime": sqltext.Append($" datetime,"); break;
                    case "FinalTestType": sqltext.Append($" int,"); break;
                    default:
                        break;
                }
            }
            sqltext.Remove(sqltext.Length - 1, 1);
            sqltext.Append(");");

            return sqltext.ToString();
        }

        public string GetAllSqlText<Entity>() where Entity : IEntity
        {

            var tableName = typeof(Entity).Name;

            return $"select * from [{tableName}] with (nolock)";
        }

        public string GetDeleteByIdText<Entity>(Guid Id) where Entity: IEntity
        {
            var tableName = typeof(Entity).Name;
            return $"delete from [{tableName}] where Id = '{Id.ToString()}'";
        }
    }
}
