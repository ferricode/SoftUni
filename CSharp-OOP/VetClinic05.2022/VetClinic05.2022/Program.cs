// See https://aka.ms/new-console-template for more information
//hats - stack
//scarfs - queue

/*if(fats>scarfs)
 * new set - > hats+scarfs
 * remove hats scarfs elements
 * else if(scarfs > hats)
 * remove hats
 * else
 * remove scarfs
 * element of hats +1
 * print
 */

int[] inputHats = Console.ReadLine().Split(" ")
    .Select(int.Parse)
    .ToArray();

int[] inputScars = Console.ReadLine().Split(" ")
    .Select(int.Parse)
    .ToArray();

Stack<int> hats = new Stack<int>(inputHats);
Queue<int> scarfs = new Queue<int>(inputScars);
List<int> elements = new List<int>();

while (hats.Count > 0 && scarfs.Count > 0)
{
    int hat = hats.Peek();
    int scarf = scarfs.Peek();

    if (hat > scarf)
    {
        elements.Add(hat + scarf);
        hats.Pop();
        scarfs.Dequeue();
    }
    else if (hat < scarf)
    {
        hats.Pop();
    }
    else {
        scarfs.Dequeue();
        int value = hats.Pop() + 1;
        hats.Push(value);
    }

}
    Console.WriteLine($"The most expensive set is: {elements.Max()}");
    Console.WriteLine(string.Join(" ",elements));