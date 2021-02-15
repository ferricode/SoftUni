using System;

namespace _03.Substring
{
    class Program
{
    static void Main(string[] args)
    {
        string removeWord = Console.ReadLine();
        string text = Console.ReadLine();

        text = text.ToLower().Replace(removeWord.ToLower(), string.Empty);
        //int index = text.IndexOf(removeWord);

        //while (index!=-1)
        //{
        //    text=text.Remove(index, removeWord.Length);
        //    index = text.IndexOf(removeWord);
        //}
        Console.WriteLine(text);
    }
}
}
