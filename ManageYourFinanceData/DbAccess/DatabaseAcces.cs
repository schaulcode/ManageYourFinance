using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourFinance.Data.DbAccess
{
    class DatabaseAcces
    {
        public static string GetConnectionString(string connectionName = "MoneyManagementDb")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static IDbConnection DbConnection(DatabaseType databaseType)
        {
            if (databaseType == DatabaseType.Sql)
            {
                return new SqlConnection(GetConnectionString());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
