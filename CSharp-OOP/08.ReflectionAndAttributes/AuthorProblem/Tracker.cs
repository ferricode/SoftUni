using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    [Author("Az")]
    public class Tracker
    {
        public void PrintMethodsByAuthor
        {
        Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in allTypes)
       {
            }
            }
}
