using System;

namespace MultipleValueEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            Days today = Days.Monday | Days.Tuesday|Days.Thursday;
            Console.WriteLine((int)today);

            Console.WriteLine((Days)today);
        }
    }
    [Flags]
    enum Days
    {
        Monday=1,
        Tuesday=2,
        Wednesday=4,
        Thursday=8,
    }
}
