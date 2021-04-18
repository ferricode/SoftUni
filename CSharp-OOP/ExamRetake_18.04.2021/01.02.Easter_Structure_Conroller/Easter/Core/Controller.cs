using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == nameof(HappyBunny))
            {
                bunnies.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunnies.Add(new SleepyBunny(bunnyName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var readyBunnies = bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy);
            var givenEgg = eggs.FindByName(eggName);

            if (readyBunnies == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            while (readyBunnies != null && !givenEgg.IsDone())
            {
                IBunny workingBunny = readyBunnies.First();
                givenEgg.GetColored();
                workingBunny.Work();

                if (workingBunny.Energy == 0)
                {
                    bunnies.Remove(workingBunny);
                }
                readyBunnies = bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy);
            }

            var status = givenEgg.IsDone() ? "done" : "not done";

            return $"Egg {eggName} is {status}.";
        }

        public string Report()
        {
            var coloredEggs = eggs.Models.Where(e => e.IsDone());

            string result = "";


            //sb.AppendLine($"{coloredEggs.Count()} eggs are done!");
            //sb.AppendLine("Bunnies info:");

            result += $"{coloredEggs.Count()} eggs are done!" + Environment.NewLine;
            result += "Bunnys info:" + Environment.NewLine;
            foreach (var bunny in bunnies.Models)
            {
                var notFinishedEggsCount = bunny.Dyes.Where(d => d.IsFinished() == false).Count();
                result += $"Name: {bunny.Name}" + Environment.NewLine;
                result += $"Energy: {bunny.Energy}" + Environment.NewLine;
                result += $"Dyes: {notFinishedEggsCount} not finished" + Environment.NewLine;
            }

            return result;
        }
    }
}
