using System;
using System.Text.Json;

namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.ID = 2;
            player.Name = "Gogi";
            player.Age = 16;
            player.Games = new int[] { 1, 2, 3 };
            player.Score = new Score();
            player.Score.Amount = 13;
            player.Score.IsTheBest = true;

            string json = JsonSerializer.Serialize(player);
            Console.WriteLine(json);
        }
    }
}
