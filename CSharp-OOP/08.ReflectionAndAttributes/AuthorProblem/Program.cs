using System;

namespace AuthorProblem
{

    [Author("Feri")]
    public class StartUp
    {
       
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
