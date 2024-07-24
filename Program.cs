using System;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace HelloWorld
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an IConfiguration object that reads configuration settings from appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") // Specifies the JSON file to use for configuration settings
                .Build(); // Builds the IConfiguration object

            // Initialize a new instance of DataContextDapper using the configuration object
            DataContextDapper dapper = new DataContextDapper(config);

            // Read the content of 'Computers.json' into a string variable to display in the console.
            string computersJson = File.ReadAllText("Computers.json");
            // // Output the content of the log file to the console.
            // Console.WriteLine(computersJson);


            // Deserialize JSON string to a collection of Computer objects using Newtonsoft.Json.
            // Newtonsoft.Json (Json.NET) has been the de facto standard for JSON processing in .NET
            // before System.Text.Json was introduced. It handles camelCase by default, 
            // requiring less configuration and resulting in simpler code.
            IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            //Checks if the deserialization was successful and the collection is not null.
            if (computersNewtonSoft != null)
            {
                // Iterates over each Computer object in the deserialized collection.
                foreach (Computer computer in computersNewtonSoft)
                {
                    // Create an SQL insert command to add the computer data to the database
                    string sql = @"INSERT INTO TutorialAppSchema.Computer (
                        Motherboard,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
                            + "','" + computer.HasWifi
                            + "','" + computer.HasLTE
                            + "','" + computer.ReleaseDate
                            + "','" + computer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                            + "','" + EscapeSingleQuote(computer.VideoCard)
                    + "')";
                    // Execute the SQL command using the Dapper context
                    dapper.ExecuteSql(sql);
                }
            }          


        }
        // Method to escape single quotes in a string to prevent SQL injection
        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");

            return output;
        }
    }




}



