
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            var dyeForColoring = bunny.Dyes.FirstOrDefault(dye => dye.Power > 0);

            while ((bunny.Energy > 0 && bunny.Dyes.Any(dye => dye.Power > 0)) || !egg.IsDone())
            {
                dyeForColoring.Use();
                if (dyeForColoring.Power==0)
                {
                    dyeForColoring = bunny.Dyes.FirstOrDefault(dye => dye.Power > 0);
                }
                bunny.Work();

                egg.GetColored();
            }
        }
    }
}
