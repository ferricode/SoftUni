using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var coffe = new Coffee("Costa", 2.7);
            
            Console.WriteLine(coffe.Price);
        }
    }
}