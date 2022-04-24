using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdoDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection conn = new SqlConnection("Server=.;Database=SoftUni;User Id=sa;Password=SoftUniJojoba;");
            await conn.OpenAsync();

            using (conn)
            {

                //string name = "David";
                string name = "' OR 1=1 --";

                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE FirstName = @firstName", conn);

                cmd.Parameters.AddWithValue("firstName", name);
                using (cmd)
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Salary = (decimal)reader["Salary"]
                            });

                            // Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]} - {reader["Salary"]}");
                        }

                    }

                }
            }
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary}");

            }
        }
    }
}
