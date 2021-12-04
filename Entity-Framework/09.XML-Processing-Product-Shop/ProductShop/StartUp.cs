using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            // ResetDb(context);
            var userXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            string categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");


            //ImportUsers(context, userXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //var result = ImportCategoryProducts(context, categoryProductsXml);

            //Console.WriteLine(result);

            //var productsInRange = GetProductsInRange(context);
            //File.WriteAllText($"../../../Results/products-in-range.xml", productsInRange);

            var categories = GetCategoriesByProductsCount(context);
            File.WriteAllText($"../../../Results/categories-by-products.xml", categories);

        }
        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";

            var usersResult = XmlConverter.Deserializer<ImportUserDto>(inputXml, root);

            List<User> users = new List<User>();

            foreach (var inportUserDto in usersResult)
            {
                var user = new User
                {
                    FirstName = inportUserDto.FirstName,
                    LastName = inportUserDto.LastName,
                    Age = inportUserDto.Age,
                };
                users.Add(user);
            }
            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";

            var productsDto = XmlConverter.Deserializer<ImportProductsDto>(inputXml, root);


            var products = productsDto.Select(p => new Product()
            {

                Name = p.Name,
                Price = p.Price,
                BuyerId = p.BuyerId,
                SellerId = p.SellerId
            })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";


        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            var categoriesDto = XmlConverter.Deserializer<ImportCategoriesDto>(inputXml, root);

            var categories = categoriesDto
                                        .Where(c => c.Name != null)
                                        .Select(c => new Category()
                                        {
                                            Name = c.Name
                                        })
                                        .ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {

            const string root = "CategoryProducts";

            var categoryProductsDto = XmlConverter.Deserializer<ImportCategoryProductsDto>(inputXml, root);


            var categories = categoryProductsDto
                .Where(i =>
                context.Categories.Any(c => c.Id == i.CategoryId) &&
                context.Products.Any(p => p.Id == i.CategoryId))
                .Select(cp => new CategoryProduct
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId
                })
                .ToArray();
            ;
            context.CategoryProducts.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";

        }
        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var products = context.Products
                                .Where(p => p.Price >= 500 && p.Price <= 1000)
                                .Select(p => new ExportProductInRangeDto
                                {
                                    Name = p.Name,
                                    Price = p.Price,
                                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                                })
                                .OrderBy(p => p.Price)
                                .Take(10)
                                .ToList();

            var result = XmlConverter.Serialize(products, root);

            return result;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";
            var users = context.Users
                        .Where(u => u.ProductsSold.Any())
                        .Select(u => new ExportUsersDto()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            SoldProducts = u.ProductsSold.Select(p => new ProductSoldDTO()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToArray()
                        })
                        .OrderBy(x => x.LastName)
                        .ThenBy(u => u.FirstName)
                        .Take(5)
                        .ToArray();

            var result = XmlConverter.Serialize(users, root);
            return result;
        }
        //p7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";
            var categories = context.Categories
                .Select(c => new CategoryProductDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categories, root);
            return result;
        }


        private static void ResetDb(ProductShopContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            // System.Console.WriteLine("Db reset success!!!");

        }
    }
}