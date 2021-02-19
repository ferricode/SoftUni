using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {

        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Capacity < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(e=> e.Name == name);

            if (employee == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e=>e.Name==name);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                result.AppendLine(employee.ToString());
            }
            return result.ToString();
        }
    }
}
