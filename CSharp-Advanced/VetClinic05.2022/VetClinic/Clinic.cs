using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        private int capacity;

        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => pets.Count;
        public void Add(Pet pet)
        {
            if (pets.Count < capacity)
            {
                pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(p => p.Name == name);
            return pets.Remove(pet);
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(pet => pet.Owner == owner && pet.Name == name);

            return pet;
        }
        public Pet GetOldestPet()
        {
            Pet pet = pets.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (Pet pet in pets)
            {
                sb.AppendLine($"Pet { pet.Name} with owner: { pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
