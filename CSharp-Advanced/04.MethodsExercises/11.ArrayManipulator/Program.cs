using System;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
            string command = Console.ReadLine();

            while (command?.ToLower() != "end")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0]?.ToLower())
                {
                    case "exchange":
                        Exchange(tokens[1], array);
                        break;
                    case "max":
                        Max(tokens[1], array);
                        break;
                    case "min":
                        Min(tokens[1], array);
                        break;
                    case "first":
                        FirstCount(tokens[1], tokens[2], array);
                        break;
                    case "last":
                        LastCount(tokens[1], tokens[2], array);
                        break;


                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", String.Join(", ", array));
        }
        private static void FirstCount(string v1, string v2, int[] array)
        {
            int count = int.Parse(v1);
            string evenOdd = v2;

            int[] firstArray = new int[count];
            int k = count - 1;

            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {

                switch (evenOdd)
                {

                    case "even":

                        for (int i = 0; i <= count - 1; i++)
                        {
                            if ((array[i] % 2) == 0)
                            {

                                firstArray[k] = array[i];
                                k++;
                            }
                        }

                        if (k == count - 1)
                        {
                            Console.WriteLine("[]");
                        }
                        else if(k==0)
                        {
                            Console.WriteLine("[{0}]", String.Join(", ", firstArray));

                        }
                        else
                        {
                            int[] print = new int[count-1-k];
                            for (int i = 0; i < print.Length; i++)
                            {
                                print[i] = firstArray[i];
                            }
                            Console.WriteLine("[{0}]", String.Join(", ", print));
                        }
                        break;

                    case "odd":
                        for (int i = 0; i <= count - 1; i++)
                        {
                            if ((array[i] % 2) != 0)
                            {

                                firstArray[k] = array[i];
                                k++;
                            }
                        }
                        if (k == count - 1)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (k == 0)
                        {
                            Console.WriteLine("[{0}]", String.Join(", ", firstArray));

                        }
                        else
                        {
                            int[] print = new int[count - 1 - k];
                            for (int i = 0; i < print.Length; i++)
                            {
                                print[i] = firstArray[i];
                            }
                            Console.WriteLine("[{0}]", String.Join(", ", print));
                        }
                        break;
                }

            }
        }
        private static void LastCount(string v1, string v2, int[] array)
        {
            int count = int.Parse(v1);
            string evenOdd = v2;

            int[] lastArray = new int[count];
            int k = count - 1;


            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {

                switch (evenOdd)
                {

                    case "even":

                        for (int i = count - 1; i >= 0; i--)
                        {
                            if ((array[i] % 2) == 0)
                            {

                                lastArray[k] = array[i];
                                k--;
                            }
                        }

                        if (k == count - 1)
                        {
                            Console.WriteLine("[]");
                        }
                        else if (k == 0)
                        {

                            Console.WriteLine("[{0}]", String.Join(", ", lastArray));
                        }
                        else
                        {
                            int[] print = new int[count - 1 - k];
                            int elements = lastArray.Length - 1;
                            for (int i = print.Length - 1; i >= 0; i--)
                            {

                                print[i] = lastArray[elements];
                                elements--;
                            }
                        }
                        break;
                    case "odd":
                        for (int i = 0; i < array.Length; i++)
                        {
                            if ((array[i] % 2) != 0)
                            {

                                lastArray[k] = array[i];
                                k--;
                            }
                        }
                        if (k == count - 1)
                        {
                            Console.WriteLine("[]");
                        }
                        else if(k==0)
                        {
                            Console.WriteLine("[{0}]", String.Join(", ", lastArray));
                        }
                        break;
                }
            }

        }

        private static void Min(string v, int[] array)
        {

            int minNum = 1001;
            int minIndex = 51;

            switch (v.ToLower())
            {
                case "odd":

                    for (int i = 0; i < array.Length; i++)
                    {
                        if ((array[i] % 2) != 0)
                        {
                            if (array[i] <= minNum)
                            {
                                minNum = array[i];
                                minIndex = i;
                            }
                        }
                    }
                    break;
                case "even":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if ((array[i] % 2) == 0)
                        {
                            if (array[i] <= minNum)
                            {
                                minNum = array[i];
                                minIndex = i;
                            }
                        }
                    }
                    break;

            }
            if (minIndex == 51)
            {
                Console.WriteLine("No matches");

            }
            else
            {
                Console.WriteLine(minIndex);
            }


        }


        private static void Max(string v, int[] array)
        {

            int maxNum = -1;
            int maxIndex = -1;

            switch (v.ToLower())
            {
                case "odd":

                    for (int i = 0; i < array.Length; i++)
                    {
                        if ((array[i] % 2) != 0 && array[i] >= maxNum)
                        {
                            maxNum = array[i];
                            maxIndex = i;

                        }
                    }
                    break;
                case "even":
                    for (int i = 0; i < array.Length; i++)
                    {
                        if ((array[i] % 2) == 0)
                        {

                            if (array[i] >= maxNum)
                            {
                                maxNum = array[i];
                                maxIndex = i;
                            }
                        }
                    }
                    break;

            }
            if (maxIndex == -1)
            {
                Console.WriteLine("No matches");

            }
            else
            {
                Console.WriteLine(maxIndex);
            }

        }

        private static void Exchange(string v, int[] array)
        {
            int index = int.Parse(v);
            int[] newArray = new int[array.Length - index - 1];
            int[] tempArray = new int[index + 1];
            string result = string.Empty;

            int k = index;
            int l = 0;

            if (index < 0 || index > array.Length)
            {
                result = "Invalid index";

            }
            for (int j = 0; j < (array.Length - index - 1); j++)
            {
                newArray[j] = array[k + 1];
                k++;
            }


            for (int i = 0; i <= index; i++)
            {
                tempArray[i] = array[i];
            }


            for (int i = 0; i < (array.Length - index - 1); i++)
            {
                array[i] = newArray[i];
            }


            for (int i = newArray.Length; i < array.Length; i++)
            {

                array[i] = tempArray[l];
                l++;
            }

        }
    }
}


