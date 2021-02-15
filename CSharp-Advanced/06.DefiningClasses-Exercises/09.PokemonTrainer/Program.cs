using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (input != "Tournament")
            {
                string[] inputArgs = input.Split();
                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);


                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }
                Trainer currentTrainer = trainers[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                currentTrainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string element = command;

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }

                }

                command = Console.ReadLine();
            }

            var result = trainers.OrderByDescending(t => t.Value.Badges).ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Value.Name} {item.Value.Badges} {item.Value.Pokemons.Count}");
            }
        }
    }
}
