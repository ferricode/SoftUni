using System;
using System.Linq;

namespace ConsoleApp48
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int length = 1;
            int bestLength = 0;
            int bestIndex = 0;
            int currSum = 0;
            int bestSum = 0;
            int seqIndex = 0;

            int bestSeqIndex = 0;
            int[] bestArray = new int[n];

            string input = Console.ReadLine();


            while (input != "Clone them!")
            {
                int[] sequance = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currIndex = 0;
                seqIndex++;
                int bestCurrentLength = 0;


                for (int i = 0; i < sequance.Length - 1; i++)
                {
                    if (sequance[i] == sequance[i + 1] && sequance[i] != 0)
                    {
                        length++;

                    }
                    else
                    {
                        length = 1;
                    }


                    if (length > bestCurrentLength)
                    {
                        bestCurrentLength = length;
                        currIndex = i;
                    }
                    currSum = sequance.Sum();



                }
                if (bestCurrentLength > bestLength)
                {
                    bestLength = bestCurrentLength;
                    bestIndex = currIndex;
                    bestSum = currSum;
                    bestSeqIndex = seqIndex;
                    bestArray = sequance.ToArray();

                }
                else if (bestCurrentLength == bestLength)
                {
                    if (currIndex < bestIndex)
                    {
                        bestLength = bestCurrentLength;
                        bestIndex = currIndex;
                        bestSum = currSum;
                        bestSeqIndex = seqIndex;
                        bestArray = sequance.ToArray();
                    }

                    else if (currIndex == bestIndex)
                    {
                        if (currSum > bestSum)
                        {
                            bestLength = bestCurrentLength;
                            bestIndex = currIndex;
                            bestSum = currSum;
                            bestSeqIndex = seqIndex;
                            bestArray = sequance.ToArray();
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSeqIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestArray));


        }



    }
}
