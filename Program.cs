using System;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;


namespace HelloWorld
{

    internal class Program
    {
        static void Main(string[] args)
        {

            DataContextDapper dapper = new DataContextDapper();          

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");



            Computer myComputer = new Computer()
            {
                ComputerId = 0,
                Motherboard = "HPZBook",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 1000.00m,
                VideoCard = "RTX 500"
            };

            //Variable Sql wird aufgesetzt als Sql befehl mit den myComputer Fields. Here we create a row.
            // and with the Statement Value we give it some Values.
            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "','" + myComputer.VideoCard
            + "')";

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            bool result = dapper.ExecuteSql(sql);

            //Console.WriteLine(result);

            string sqlSelect = @"
            SELECT 
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            Console.WriteLine("'Motherboard','HasWifi','HasLTE','ReleaseDate'"
                + ",'Price','VideoCard'");
            foreach (Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.HasLTE
                    + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + singleComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "','" + singleComputer.VideoCard + "'");
            }


        }
    }




}



