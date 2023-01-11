using Microsoft.Data.SqlClient;
using NorthwindProject.Configuration;

namespace NorthwindProject.Models
{
    public class DbConnector
    {
        private static AppSettings? _settings;

        public static void Initialize(AppSettings appSettings)
        {
            _settings = appSettings;
        }
        public static SqlConnection? GetServiceConnection()
        {
            if (_settings == null)
                return null;

			//get connection to database
            return GetConnection(_settings.ConnectionStrings.Default);
        }

        private static SqlConnection GetConnection(string connStr)
        {
            //create new connection
            SqlConnection sqlConn = new SqlConnection(connStr);

            //make sure we're not returning null
            if (sqlConn == null)
                throw new Exception("Error connecting to database.");

            //open newly created connection
            sqlConn.Open();

            return sqlConn;
        } //end method GetConnection
    } //end class DbConnector
}
