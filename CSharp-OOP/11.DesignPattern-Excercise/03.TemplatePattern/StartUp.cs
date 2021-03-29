using System;

namespace _03.TemplatePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
