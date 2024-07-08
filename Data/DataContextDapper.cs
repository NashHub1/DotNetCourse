using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data
{

    public class DataContextDapper
    {
        // Connection string to the SQL Server database
        private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

        // Generic method to retrieve data from the database
        // T represents the type of data to be returned
        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Execute the SQL query and return the result as an IEnumerable of type T
            return dbConnection.Query<T>(sql);

        }
        // Generic method to retrieve a single record from the database
        // T represents the type of data to be returned
        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Execute the SQL query and return a single result of type T
            return dbConnection.QuerySingle<T>(sql);
        }

        // Method to execute a SQL command that does not return any data (e.g., INSERT, UPDATE, DELETE)
        // Returns a boolean indicating if the operation affected any rows
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // Execute the SQL command and return true if any rows were affected
            return (dbConnection.Execute(sql) > 0);
        }

        // Method to execute a SQL command that does not return any data (e.g., INSERT, UPDATE, DELETE)
        // Returns the number of rows affected by the operation
        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }
    }

}