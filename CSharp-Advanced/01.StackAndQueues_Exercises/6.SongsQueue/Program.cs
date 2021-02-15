using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songs = new Queue<string>(input);

            string command = Console.ReadLine();

            while (songs.Any())
            {
                string[] Args = command.Split().ToArray();

                Queue<string> tokens = new Queue<string>(Args);

                switch (tokens.Peek())
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        
                        string cmd = tokens.Dequeue();
                        string song = string.Join(" ", tokens);
                    
                        if (!songs.Contains(song))
                        {
                            songs.Enqueue(song); 
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;

                }
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
