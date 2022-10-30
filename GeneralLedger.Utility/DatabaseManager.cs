using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace GeneralLedger.Utility
{
    public class DatabaseManager
    {
        private string _ConnectionName = string.Empty;

        public string ConnectionName
        {
            get { return _ConnectionName; }
            set { _ConnectionName = value; }
        }

        public DbConnection getDBConnection()
        {
            ConnectionStringSettings connStringSettings = ConfigurationManager.ConnectionStrings[_ConnectionName];
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connStringSettings.ProviderName);
            DbConnection dbConn = dbFactory.CreateConnection();

            string strConnection = connStringSettings.ConnectionString;

            dbConn.ConnectionString = strConnection;
            return dbConn;
        }

        public DbConnection getDBConnection(string connectionname)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.ConnectionName = connectionname;

            return dbManager.getDBConnection();
        }

        public SqlConnection getSQLConnection()
        {
            ConnectionStringSettings connStringSettings = ConfigurationManager.ConnectionStrings[_ConnectionName];

            string strConnection = connStringSettings.ConnectionString;

            SqlConnection sqlConn = new SqlConnection(strConnection);

            return sqlConn;
        }

        public SqlConnection getSQLConnection(string connectionname)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.ConnectionName = connectionname;

            return dbManager.getSQLConnection();
        }

        public string getSQLConnectionString(string connectionname)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.ConnectionName = connectionname;


            return dbManager.getSQLConnection().ConnectionString;
        }
    }
}
