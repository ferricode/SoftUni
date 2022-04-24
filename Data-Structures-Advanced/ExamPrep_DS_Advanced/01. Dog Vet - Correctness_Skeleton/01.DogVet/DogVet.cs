namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogs;
        private Dictionary<string, LinkedList<Dog>> dogsByOwnerId;
        private Dictionary<string, Owner> owners;

        public DogVet()
        {
            this.dogs = new Dictionary<string, Dog>();
            this.dogsByOwnerId = new Dictionary<string, LinkedList<Dog>>();
            this.owners = new Dictionary<string, Owner>();
        }
        public int Size { get => dogs.Count; }
        public void AddDog(Dog dog, Owner owner)
        {
            if (this.Contains(dog))
            {
                throw new ArgumentException();
            }
            dogs[dog.Id] = dog;

            if (!dogsByOwnerId.ContainsKey(owner.Id))
            {
                dogsByOwnerId[owner.Id] = new LinkedList<Dog>();
                dogsByOwnerId[owner.Id].AddLast(dog);
            }
            else if (dogsByOwnerId.ContainsKey(owner.Id) && dogsByOwnerId[owner.Id].Contains(dog))
            {
                throw new ArgumentException();
            }

            if (!owners.ContainsKey(owner.Id))
            {
                owners[owner.Id] = owner;
            }
        }

        public bool Contains(Dog dog)
        {
            return dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {

            if (!dogsByOwnerId.ContainsKey(ownerId) || dogsByOwnerId[ownerId].FirstOrDefault(dogs => dogs.Name == name) == null)
            {
                throw new ArgumentException();

            }
            return dogsByOwnerId[ownerId].FirstOrDefault(dogs => dogs.Name == name);
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!dogs.Values.Any(d => d.Name == name) || !owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }
            var dogToRemove = dogs.Values.FirstOrDefault(d => d.Name == name);

            dogs.Remove(dogToRemove.Id);
            dogsByOwnerId[ownerId].Remove(dogToRemove);
            return dogToRemove;
        }
        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!dogsByOwnerId.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }
            return dogsByOwnerId[ownerId];
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (dogs.Count==0)
            {
                throw new ArgumentException();
            }

            return dogs.Values.Where(d => d.Breed == breed);
        }

        public void Vaccinate(string name, string ownerId)
        {

            if (!dogsByOwnerId.ContainsKey(ownerId) || dogsByOwnerId[ownerId].FirstOrDefault(dogs => dogs.Name == name) == null)
            {
                throw new ArgumentException();

            }
            var dogTovaccinate = dogsByOwnerId[ownerId].FirstOrDefault(dogs => dogs.Name == name);

            dogs[dogTovaccinate.Id].Vaccines++;
            dogsByOwnerId[ownerId].FirstOrDefault(d => d == dogTovaccinate).Vaccines++;

        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            throw new NotImplementedException();
        }
    }
}