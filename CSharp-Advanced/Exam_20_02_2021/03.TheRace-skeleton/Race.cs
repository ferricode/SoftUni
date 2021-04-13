using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data = new List<Racer>();

        public Race(string name, int capacity)
        {
            this.data = new List<Racer>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            Racer currRacer = data.FirstOrDefault(r => r.Name == name);
            if (currRacer!=null)
            {
                data.Remove(currRacer);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public Racer GetOldestRacer()
        {
            if (data.Count > 0)
            {
                return data.OrderByDescending(r => r.Age).First();

            }
            return null;
        }
        public Racer GetRacer(string name)
        {
            Racer currRacer = data.FirstOrDefault(r => r.Name == name);
            if (data.Contains(currRacer))
            {

                return currRacer;
            }
            return null;

        }
        public Racer GetFastestRacer()
        {
            Racer currRacer = data.OrderByDescending(r => r.Car.Speed).First();
            if (data.Contains(currRacer))
            {

                return currRacer;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data)
            {
                output.AppendLine(racer.ToString());
            }
            return output.ToString().TrimEnd();
        }
    }
}
