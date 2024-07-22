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
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);


            // //Variable Sql wird aufgesetzt als Sql befehl mit den myComputer Fields. Here we create a row.
            // // and with the Statement Value we give it some Values.
            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard
            //         + "','" + myComputer.HasWifi
            //         + "','" + myComputer.HasLTE
            //         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //         + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
            //         + "','" + myComputer.VideoCard
            // + "')";

            // // Write the SQL command to a text file named 'log.txt', overwriting it if it already exists.
            // File.WriteAllText("log.txt", "\n" + sql + "\n");

            // // Append additional SQL command executions to 'log.txt' using a StreamWriter. So we add new String and don't overwrite.
            // using StreamWriter openFile = new("log.txt", append: true);
            // openFile.WriteLine("\n" + sql + "\n"); // Append the SQL command to the file.

            // openFile.Close(); // Close the StreamWriter to release file resources.

            // Read the content of 'log.txt' into a string variable to display in the console.
            string computersJson = File.ReadAllText("Computers.json");

            // // Output the content of the log file to the console.
            // Console.WriteLine(computersJson);
            

            // Deserialize JSON string to a collection of Computer objects using Newtonsoft.Json.
            // Newtonsoft.Json (Json.NET) has been the de facto standard for JSON processing in .NET
            // before System.Text.Json was introduced. It handles camelCase by default, 
            // requiring less configuration and resulting in simpler code.
            IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computersNewtonSoft != null)
            {
                // Iterate over the deserialized collection and print the Motherboard property of each Computer object.
                foreach (Computer computer in computersNewtonSoft)
                {
                    System.Console.WriteLine(computer.Motherboard);
                }
            }
            // How to Serialize again
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);
            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);






            /*// The commented-out code below demonstrates how to use System.Text.Json for deserialization.
            // It requires setting JsonSerializerOptions to handle camelCase naming conventions, which 
            // is not the default behavior and must be explicitly defined. */
            // JsonSerializerOptions options = new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };
            // Deserialize JSON string to a collection of Computer objects using System.Text.Json with options.
            //IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // Serialize again with:
            //string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            // File.WriteAllText("computersCopySystem.txt", computersCopySystem);


        }
    }




}



