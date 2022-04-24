using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, Vehicle> vehiclesById;
        private Dictionary<string, LinkedList<Vehicle>> sellerVehicles;
        private Dictionary<string, LinkedList<Vehicle>> byBrands;
        private Dictionary<string, string> sellerByVehicleId;
        public VehicleRepository()
        {
            this.vehiclesById = new Dictionary<string, Vehicle>();
            this.sellerVehicles = new Dictionary<string, LinkedList<Vehicle>>();
            this.byBrands = new Dictionary<string, LinkedList<Vehicle>>();
            this.sellerByVehicleId = new Dictionary<string, string>();
        }
        public int Count => vehiclesById.Count;
        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            this.sellerByVehicleId.Add(vehicle.Id, sellerName);
            this.vehiclesById.Add(vehicle.Id, vehicle);

            if (!sellerVehicles.ContainsKey(sellerName))
            {
                sellerVehicles[sellerName] = new LinkedList<Vehicle>();
            }
            sellerVehicles[sellerName].AddLast(vehicle);

            if (!byBrands.ContainsKey(vehicle.Brand))
            {
                byBrands[vehicle.Brand] = new LinkedList<Vehicle>();
            }
            byBrands[vehicle.Brand].AddLast(vehicle);

        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!sellerVehicles.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            Vehicle cheapestVehicle = sellerVehicles[sellerName].OrderBy(v => v.Price).FirstOrDefault();

            this.RemoveVehicle(cheapestVehicle.Id);
            return cheapestVehicle;
        }

        public bool Contains(Vehicle vehicle)
        {
            return vehiclesById.ContainsKey(vehicle.Id);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException();
            }

            //foreach (var item in byBrands.Values)
            //{
            //    item.OrderBy(v => v.Price);
            //}
            //return byBrands;


            return this.byBrands
                .ToDictionary(
                v => v.Key,
                v => v.Value.OrderBy(vehicle => vehicle.Price).ToList());

        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            //по-бавен вариант 
            //foreach (var item in sellerVehicles.Values)
            //{
            //    item.OrderByDescending(v => v.Horsepower).ThenBy(v => v.Price);
            //}

            //return (IEnumerable<Vehicle>)sellerVehicles.OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            return this.vehiclesById
                .Values
                .OrderByDescending(vehicle => vehicle.Horsepower)
                .ThenBy(vehicle => vehicle.Price)
                .ThenBy(vehicle => this.sellerByVehicleId[vehicle.Id]);
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            return this.vehiclesById.Values
                .Where(vehicle => keywords.Contains(vehicle.Brand)
                || keywords.Contains(vehicle.Model)
                || keywords.Contains(vehicle.Location)
                || keywords.Contains(vehicle.Color))
                .OrderBy(vehicle => !vehicle.IsVIP)
                .ThenBy(vehicle => vehicle.Price);
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!sellerByVehicleId.ContainsValue(sellerName))
            {
                throw new ArgumentException();
            }
            return sellerVehicles[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            return vehiclesById.Values
                .Where(v => v.Price >= lowerBound && v.Price <= upperBound)
                .OrderByDescending(v => v.Horsepower);
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!this.vehiclesById.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }
            var vehicleToRemove = vehiclesById[vehicleId];

            this.sellerVehicles[this.sellerByVehicleId[vehicleId]].Remove(vehicleToRemove);
            this.byBrands[vehicleToRemove.Brand].Remove(vehicleToRemove);
            this.vehiclesById.Remove(vehicleId);
            this.sellerByVehicleId.Remove(vehicleId);
        }
    }
}
