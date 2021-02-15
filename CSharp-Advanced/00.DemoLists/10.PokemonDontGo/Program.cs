using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonDistance = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();


            int sumOfCaptured = 0;

            while (pokemonDistance.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                int captured = 0;


                if (index < 0)
                {
                    captured += pokemonDistance[0];
                    pokemonDistance.RemoveAt(0);
                    pokemonDistance.Insert(index, pokemonDistance[pokemonDistance.Count - 1]);
                }
                else if (index > pokemonDistance.Count - 1)
                {
                    captured += pokemonDistance[pokemonDistance.Count - 1];
                    pokemonDistance.RemoveAt(pokemonDistance.Count - 1);
                    pokemonDistance.Add(pokemonDistance[0]);
                }
                else
                {
                    captured += pokemonDistance[index];
                    pokemonDistance.RemoveAt(index);

                }
                sumOfCaptured += captured;

                for (int i = 0; i <= pokemonDistance.Count - 1; i++)
                {
                    if (pokemonDistance[i] <= captured)
                    {
                        pokemonDistance[i] += captured;
                    }
                    else if (pokemonDistance[i] > captured)
                    {
                        pokemonDistance[i] -= captured;
                    }
                }


            }
            Console.WriteLine(sumOfCaptured);

        }
    }
}
