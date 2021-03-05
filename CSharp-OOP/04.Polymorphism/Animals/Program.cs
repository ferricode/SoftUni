using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Cat("Koti", "Negatiwni emocii");
            Console.WriteLine(animal.ExplainSelf());

            animal = new Dog("Ku4ee", "Pozitivni emocii");
            Console.WriteLine(animal.ExplainSelf());
        }
    }
}
