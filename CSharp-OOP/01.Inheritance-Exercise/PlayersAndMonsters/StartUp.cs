using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var elf = new Elf("Elf", 100);
            Console.WriteLine(elf);

            var darkWizard = new DarkWizard("DarkWiz2", 239);
            Console.WriteLine(darkWizard);
        }
    }
}