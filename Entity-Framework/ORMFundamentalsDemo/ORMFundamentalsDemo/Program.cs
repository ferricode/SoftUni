using System;
using System.Linq;

namespace ORMFundamentalsDemo
{
    class Program
    {
        //Microsoft.EntityFrameworkCore.SqlServer
        //Microsoft.EntityFrameworkCore.Design

        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(db.Employees.Count());

            foreach (var employee in db.Employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            //Console.WriteLine(new SoftUniContext().Employees.Count());
        }
    }
}
