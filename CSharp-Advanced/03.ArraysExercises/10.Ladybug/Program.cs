using System;
using System.Linq;

namespace _10.Ladybug
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] field = new int[size];
            string input = string.Empty;
            int[] ladybugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;

            for (int i = 0; i < ladybugIndexes.Length; i++)
            {
                int currentIndex = ladybugIndexes[i];
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 1;
                }
            }

            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentLadyBug = input.Split();
                int ladybugPosition = int.Parse(currentLadyBug[0]);
                string movingDirection = currentLadyBug[1];
                int ladybugFlyLength = int.Parse(currentLadyBug[2]);

                if (ladybugPosition < 0 || ladybugPosition > field.Length - 1 || field[ladybugPosition] == 0)
                {
                    continue;
                }
                field[ladybugPosition] = 0;
                if (movingDirection == "left")
                {
                    index = ladybugPosition - ladybugFlyLength;
                    if (index < 0)
                    {
                        continue;
                    }
                    if (field[index] == 1)
                    {
                        while (field[index] == 1)
                        {
                            index -= ladybugFlyLength;
                            if (index < 0)
                            {
                                break;
                            }
                        }

                    }
                    if (index >= 0 && index <= field.Length - 1)
                    {
                        field[index] = 1;
                    }
                }
                else if (movingDirection == "right")
                {
                    index = ladybugPosition + ladybugFlyLength;
                    if (index > field.Length - 1)
                    {
                        continue;
                    }
                    if (field[index] == 1)
                    {
                        while (field[index] == 1)
                        {
                            index += ladybugFlyLength;
                            if (index > field.Length - 1)
                            {
                                break;
                            }
                        }

                    }
                    if (index >= 0 && index <= field.Length - 1)
                    {
                        field[index] = 1;
                    }

                }


            }
            Console.WriteLine(string.Join(' ', field));
        }
    }
}



