﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine().Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            List<string> townRawData = firstTupleData.ToList().Skip(3).ToList();
            string town = string.Join(" ", townRawData);
            Threeuple<string, string, string>firstTreeuple=
             new Threeuple<string, string, string>(fullName, firstTupleData[2], town);

            string[] secondTupleData = Console.ReadLine().Split(" ");
            bool drunk = secondTupleData[2] == "drunk";
            Threeuple<string, int, bool> secondTreeuple =
             new Threeuple<string, int, bool>(secondTupleData[0], int.Parse(secondTupleData[1]), drunk);

            string[] thirdTupleData = Console.ReadLine().Split(" ");
            Threeuple<string, double, string> thirdThreeuple =
                new Threeuple<string, double, string>(thirdTupleData[0], double.Parse(thirdTupleData[1]), thirdTupleData[2]);

            Console.WriteLine(firstTreeuple);
            Console.WriteLine(secondTreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
