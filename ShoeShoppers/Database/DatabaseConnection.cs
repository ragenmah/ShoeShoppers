using System;
using System.Data.SqlClient;

namespace ShoeShoppers.Database
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private readonly SqlConnection _connection;

        private DatabaseConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                }
                return _instance;
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                //if (_connection.State == System.Data.ConnectionState.Closed)
                //{
                //    _connection.Open();
                //}

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
                //return _connection;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Cannot open database connection.", ex);
            };
        }

        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}