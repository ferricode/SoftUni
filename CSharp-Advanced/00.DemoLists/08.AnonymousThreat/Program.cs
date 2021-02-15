using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
                                           .Split()
                                           .ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] cmdArgs = command.Split().ToArray();

                if (cmdArgs[0] == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    string concatData = string.Empty;
                    //int count = 0;

                    if (startIndex < 0)
                    {
                        if (endIndex >= 0 && endIndex <= inputLine.Count - 1)
                        {
                            startIndex = 0;
                        }

                    }
                    if (endIndex > inputLine.Count - 1)
                    {
                        if (startIndex >= 0 && startIndex <= inputLine.Count - 1)
                        {
                            endIndex = inputLine.Count - 1;
                        }
                    }
                    if ((startIndex >= 0 && startIndex <= inputLine.Count - 1) &&
                        (endIndex >= 0 && endIndex <= inputLine.Count - 1))
                    {

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            concatData += inputLine[i];
                        }
                        inputLine.RemoveRange(startIndex, endIndex - startIndex + 1);
                        inputLine.Insert(startIndex, concatData);
                        //count = endIndex - startIndex + 1;
                        //inputLine[startIndex] = string.Join("", inputLine.ToArray(), startIndex, count);
                        //for (int i = endIndex; i >= startIndex + 1; i--)
                        //{
                        //    inputLine.RemoveAt(i);
                        //}
                    }

                }
                else if (cmdArgs[0] == "divide")
                {

                    int index = int.Parse(cmdArgs[1]);
                    int partitions = int.Parse(cmdArgs[2]);

                    if (index >= 0 && index <= inputLine.Count - 1)
                    {

                        string word = inputLine[index];
                        List<string> dividedWord = new List<string>();
                        int stringLengthToAdd = word.Length / partitions;

                        int startIndex = 0;
                        for (int i = 0; i < partitions; i++)
                        {
                            if (i == partitions - 1)
                            {
                                dividedWord.Add(word.Substring(startIndex, word.Length - startIndex));
                            }
                            else
                            {
                                dividedWord.Add(word.Substring(startIndex, stringLengthToAdd));
                                startIndex += stringLengthToAdd;
                            }
                        }
                        inputLine.RemoveAt(index);
                        inputLine.InsertRange(index, dividedWord);

                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", inputLine));
        }


    }
}
