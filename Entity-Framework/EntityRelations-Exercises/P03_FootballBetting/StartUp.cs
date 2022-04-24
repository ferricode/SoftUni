using P03_FootballBetting.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Db created successfulluy!");

            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("Db created successfulluy!");
            //Console.WriteLine("Do you want to delete database(Y/N)?");
            //string result = Console.ReadLine();

            //if (result == "Y")
            //{
            //    dbContext.Database.EnsureDeleted();
            //}

        }
    }
}
