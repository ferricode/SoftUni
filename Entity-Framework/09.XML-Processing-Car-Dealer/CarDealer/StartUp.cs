using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            CarDealerContext dbContext = new CarDealerContext();

            //ResetDb(dbContext);
            //string supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //ImportSuppliers(dbContext, supplierXml);
            //ImportParts(dbContext, partsXml);
            //ImportCars(dbContext, carsXml);
            //ImportCustomers(dbContext, customersXml);

            //ImportSales(dbContext, salesXml);
            string result = GetSalesWithAppliedDiscount(dbContext);

            Console.WriteLine(result);

        }
        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportSupplierDto[] dtos = (ImportSupplierDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Supplier> suppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto supplierDto in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = bool.Parse(supplierDto.IsImporter)
                };
                suppliers.Add(s);

            }
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            ImportPartDto[] partsDtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (ImportPartDto partDto in partsDtos)
            {
                Supplier supplier = context
                    .Suppliers
                    .Find(partDto.SupplierId);

                if (supplier == null)
                {
                    continue;
                }

                Part p = new Part()
                {
                    Name = partDto.Name,
                    Price = decimal.Parse(partDto.Price),
                    Quantity = partDto.Quantity,
                    SupplierId = supplier.Id

                };
                parts.Add(p);

            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";

        }
        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = GenerateXmlSerializer("Cars", typeof(ImportCarDto[]));
            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();

            foreach (ImportCarDto carDto in carDtos)
            {
                Car c = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                ICollection<PartCar> currentCarParts = new HashSet<PartCar>();

                foreach (int partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Find(partId);

                    if (part == null)
                    {
                        continue;
                    }
                    PartCar partCar = new PartCar()
                    {
                        Car = c,
                        Part = part
                    };
                    currentCarParts.Add(partCar);
                }

                c.PartCars = currentCarParts;
                cars.Add(c);
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            InitializeAutoMapper();
            var customerDto = XmlConverter.Deserializer<ImportCustomerDto>(inputXml, root);
            var customers = mapper.Map<Customer[]>(customerDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var salesDto = XmlConverter.Deserializer<ImportSaleDto>(inputXml, root);

            var carsId = context.Cars.Select(x => x.Id).ToList();

            var sales = salesDto
                        .Where(x => carsId.Contains(x.CarId))
                        .Select(x => new Sale
                        {
                            CarId = x.CarId,
                            CustomerId = x.CustomerId,
                            Discount = x.Discount
                        })
                        .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {

            //StringBuilder sb = new StringBuilder();
            //using StringWriter stringWriter = new StringWriter(sb);

            //XmlSerializer xmlSerializer = GenerateXmlSerializer("cars", typeof(ExportCarsWithDistanceDto[]));

            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(String.Empty, String.Empty);

            ExportCarsWithDistanceDto[] carsDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .ToArray();

            //xmlSerializer.Serialize(stringWriter, carsDtos, namespaces);
            //return sb.ToString().TrimEnd();

            var result = XmlConverter.Serialize(carsDtos, "cars");
            return result;

        }
        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportBMWDto[] carsDtos = context.Cars
                        .Where(c => c.Make == "BMW")
                        .Select(x => new ExportBMWDto()
                        {
                            Id = x.Id,
                            Model = x.Model,
                            TravelledDistance = x.TravelledDistance
                        })
                        .OrderBy(c => c.Model)
                        .ThenByDescending(c => c.TravelledDistance)
                        .ToArray();

            var result = XmlConverter.Serialize(carsDtos, "cars");

            return result;
        }
        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliersDto = context.Suppliers
                    .Where(x => !x.IsImporter)
                    .Select(x => new ExportLocalSuppliersDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        PartsCount = x.Parts.Count()
                    })
                    .ToArray();
            var result = XmlConverter.Serialize(suppliersDto, "suppliers");

            return result;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            var carsDto = context.Cars
                .Select(c => new ExportCarPartDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new CartPartInfoDto()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            var result = XmlConverter.Serialize(carsDto, "cars");
            return result;
        }
        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                            .Where(c => c.Sales.Count > 0)
                            .Select(c => new ExportCustomersDto()
                            {
                                FullName = c.Name,
                                BoughtCars = c.Sales.Count,
                                SpentMoney = c.Sales.Select(x => x.Car).SelectMany(x => x.PartCars).Sum(x => x.Part.Price)
                            }
                            )
                            .OrderByDescending(c => c.SpentMoney)
                            .ToList();

            var result = XmlConverter.Serialize(customers, "customers");
            return result;

        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                        .Select(s => new ExportSalesCarDto()
                        {
                            Car = new CarSaleDto()
                            {
                                Make = s.Car.Make,
                                Model = s.Car.Model,
                                TravelledDistance = s.Car.TravelledDistance
                            },
                            CustomerName = s.Customer.Name,
                            Discount = s.Discount,
                            Price = s.Car.PartCars.Sum(x => x.Part.Price),
                            /*PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) - (s.Car.PartCars.Sum(x => x.Part.Price)) * s.Discount / 100*/
                            PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price)*((100-s.Discount)/100)
                          
                        })
                        .ToList();
            var result = XmlConverter.Serialize(sales, "sales");
            return result;
        }
        private static void ResetDb(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            // System.Console.WriteLine("Db reset success!!!");

        }
        private static XmlSerializer GenerateXmlSerializer(string rootname, Type dtoType)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootname);
            XmlSerializer xmlSerializer = new XmlSerializer(dtoType, xmlRoot);

            return xmlSerializer;

        }
        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}