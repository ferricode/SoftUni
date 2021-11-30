using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var jsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //var jsonParts = File.ReadAllText("../../../Datasets/parts.json");
            //var jsonCars = File.ReadAllText("../../../Datasets/cars.json");
            //var jsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            //var jsonSales = File.ReadAllText("../../../Datasets/sales.json");


            //Console.WriteLine(ImportSuppliers(context, jsonSuppliers));
            //Console.WriteLine(ImportParts(context, jsonParts));
            //Console.WriteLine(ImportCars(context, jsonCars));
            //Console.WriteLine(ImportCustomers(context, jsonCustomers));
            //Console.WriteLine(ImportSales(context, jsonSales));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                            .Take(10)
                            .Select(s => new
                            {
                                car = new
                                {
                                    Make = s.Car.Make,
                                    Model = s.Car.Model,
                                    TravelledDistance = s.Car.TravelledDistance
                                },

                                customerName = s.Customer.Name,
                                Discount = s.Discount.ToString("f2"),
                                price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                                priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100)).ToString("F2")
                            })
                            .ToList();
           

            var resultJson = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return resultJson;
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersBySales = context.Customers
                                    .Where(c => c.Sales.Count != 0)
                                    .Select(c => new
                                    {
                                        fullName = c.Name,
                                        boughtCars = c.Sales.Count,
                                        spentMoney = c.Sales
                                             .SelectMany(s => s.Car.PartCars.Select(pc => pc.Part.Price)).Sum()
                                    })
                                    .OrderByDescending(c => c.spentMoney)
                                    .ThenByDescending(c => c.boughtCars)
                                    .ToList();

            var resultJson = JsonConvert.SerializeObject(customersBySales, Formatting.Indented);
            return resultJson;

        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                                .Select(c => new
                                {
                                    car = new
                                    {
                                        Make = c.Make,
                                        Model = c.Model,
                                        TravelledDistance = c.TravelledDistance,
                                    },

                                    parts = c.PartCars.Select(pc => new
                                    {
                                        Name = pc.Part.Name,
                                        Price = pc.Part.Price.ToString("f2")
                                    })
                                    .ToList()
                                })
                                .ToList();
            var resultJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return resultJson;

        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(s => new
                            {
                                Id = s.Id,
                                Name = s.Name,
                                PartsCount = s.Parts.Count
                            })
                            .ToList();

            var resultJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return resultJson;
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                        .Where(c => c.Make == "Toyota")
                        .OrderBy(c => c.Model)
                        .ThenByDescending(c => c.TravelledDistance)
                        .Select(c => new
                        {
                            Id = c.Id,
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance
                        })
                        .ToList();

            var resultJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return resultJson;
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                    .OrderBy(x => x.BirthDate)
                    .ThenBy(x => x.IsYoungDriver)
                    .Select(x => new
                    {
                        Name = x.Name,
                        BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                        IsYoungDriver = x.IsYoungDriver
                    })
                    .ToArray();


            var resultJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return resultJson;

        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<IEnumerable<ImportSalesDto>>(inputJson);

            var sales = salesDto.Select(x => new Sale
            {
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                Discount = x.Discount
            })
            .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<IEnumerable<ImportCustomersModel>>(inputJson);
            var customers = customersDto.Select(x => new Customer
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungerDriver
            })
            .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";

        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<IEnumerable<ImportCarModel>>(inputJson);

            var listOfCars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };
                foreach (var partId in car?.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }
                listOfCars.Add(currentCar);
            }

            context.Cars.AddRange(listOfCars);
            context.SaveChanges();

            return $"Successfully imported {listOfCars.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierId = context.Suppliers
                                  .Select(x => x.Id)
                                  .ToArray();

            var partsDtos = JsonConvert
                            .DeserializeObject<IEnumerable<ImportPartsModel>>(inputJson)
                            .Where(s => supplierId.Contains(s.SupplierId))
                            .ToList();

            var parts = partsDtos.Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            })
             .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDtos = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = suppliersDtos.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToList();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
    }
}