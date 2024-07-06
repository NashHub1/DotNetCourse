using System;
using System.Data;
using System.Dynamic;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;


namespace HelloWorld
{

    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionsString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection = new SqlConnection(connectionsString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow =dbConnection.QuerySingle<DateTime>(sqlCommand);

            System.Console.WriteLine(rightNow);



        }
    }




}



