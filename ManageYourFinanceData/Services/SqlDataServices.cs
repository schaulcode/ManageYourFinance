using Dapper;
using ManageYourFinance.Data.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.Services
{
    public class SqlDataServices<T>: IDataServices<T>
    {
        readonly Type instanceType;
        readonly PropertyInfo[] properties;
        readonly IDbConnection db;

        public SqlDataServices()
        {
            instanceType = this.GetType().GenericTypeArguments[0];
            properties = instanceType.GetProperties();
            db = DatabaseAcces.DbConnection(DatabaseType.Sql);
        }

        public void Add(T data)
        {
            string sql = $"INSERT INTO dbo.{instanceType.Name} ({GeneratePropertyString()}) VALUES({GeneratePropertyValuesString()})";
            db.Execute(sql, data);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM dbo.{instanceType.Name} WHERE ID = @id";
            db.Execute(sql, new { id = id });
        }

        public void Edit(int id, T data)
        {
            string sql = $"UPDATE dbo.{instanceType.Name} SET {GeneratePropertyEditString()} WHERE ID = @id";
            db.Execute(sql, data);
        }

        public T Get(int id)
        {
            string sql = $"sELECT * FROM dbo.{instanceType.Name} WHERE ID = @id";
            return db.QueryFirst<T>(sql, new { id = id });
        }

        public List<T> GetAll(int? id = null, Type relationDb = null)
        {
            string sql = $"SELECT * FROM dbo.{instanceType.Name}";
            if (id.HasValue && relationDb !=  null)
            {
                sql += $" WHERE {relationDb.Name}ID = {id}";
            }
            return db.Query<T>(sql).ToList();
        }

        public List<T> GetAll(string columnName, DateTime date, string expression = "=")
        {
            string sql = $"SELECT * FROM dbo.{instanceType.Name} WHERE {columnName} {expression} '{date.ToString("O")}' ";
            return db.Query<T>(sql).ToList();
        }

        private string GeneratePropertyEditString()
        {
            string propertyString = "";
            foreach (var item in properties)
            {
                if (item.Name == "ID") continue;
                propertyString += item.Name + " = @" +item.Name + ",";
            }
            return propertyString.TrimEnd(',');
        }

        private string GeneratePropertyString()
        {
            string propertyString = "";
            foreach (var item in properties)
            {
                if (item.Name == "ID") continue;
                propertyString += item.Name + ",";
            }
            return propertyString.TrimEnd(',');
        }

        private string GeneratePropertyValuesString()
        {
            string propertyString = "";
            foreach (var item in properties)
            {
                if (item.Name == "ID") continue;
                propertyString += "@" + item.Name + ",";
            }
            return propertyString.TrimEnd(',');
        }
    }
}
