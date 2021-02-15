using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> addFunc = num => num += 1; // num++/ ++nume/num+1
            Func<int, int> subtractFunc = num => num -= 1;// num--/--num/num-1
            Func<int, int> multiplyFunc = num => num *= 2;
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();
            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                switch (command.ToLower())
                {
                    case "add":
                        numbers = numbers.Select(addFunc).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiplyFunc).ToArray();
                        break;

                    case "subtract":
                        numbers = numbers.Select(subtractFunc).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                command = Console.ReadLine();
            }


        }
    }
}

