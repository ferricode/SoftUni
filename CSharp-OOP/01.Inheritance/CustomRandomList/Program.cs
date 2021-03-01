using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("gosho");
            list.Add("gosho1");
            list.Add("gosho2");
            list.Add("gosho3");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }

            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.RandomString());
            //Console.WriteLine(list.Count);
        }
    }
}
