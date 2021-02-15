using System;
using System.IO;

namespace NumberedeLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                        int row = 1;
                    while (line!=null)
                    {
                        line.Insert(0, row.ToString());
                        row++;
                        writer.WriteLine();
                        line = reader.ReadLine();
                    }

                }

            }
        }
    }
}
