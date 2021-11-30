using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{

    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            //productShopContext.Database.EnsureDeleted();
            //productShopContext.Database.EnsureCreated();

            //string usersJason = File.ReadAllText("../../../Datasets/users.json");
            //string productsJason = File.ReadAllText("../../../Datasets/products.json");
            //string categoriesJason = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriesProductsJason = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(productShopContext, usersJason);
            //ImportProducts(productShopContext, productsJason);
            //ImportCategories(productShopContext, categoriesJason);
            //var result = ImportCategoryProducts(productShopContext, categoriesProductsJason);

            var result = GetUsersWithProducts(productShopContext);
            Console.WriteLine(result);
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                           .Include(x => x.ProductsSold)
                           .ToArray()
                           .Where(x => x.ProductsSold.Count > 0 )
                           .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                age = u.Age,
                                soldProducts = new
                                {
                                    count = u.ProductsSold.Where(x => x.BuyerId != null).Count(),
                                    products = u.ProductsSold.Where(x => x.BuyerId != null).Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                                }
                            })
                           .OrderByDescending(x => x.soldProducts.products.Count())
                           .ToArray();
            var resultObjects = new
            {
                usersCount = users.Count(),
                users = users

            };
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var resultJson = JsonConvert.SerializeObject(resultObjects, Formatting.Indented, jsonSerializerSettings);

            return resultJson;

        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesInfo = context.Categories
                            .Select(c => new
                            {
                                category = c.Name,
                                productsCount = c.CategoryProducts.Count,
                                averagePrice = c.CategoryProducts.Count == 0 ?
                                0.ToString("F2") :
                                c.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                                totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                            })
                            .OrderByDescending(x => x.productsCount)
                            .ToList();
            var result = JsonConvert.SerializeObject(categoriesInfo, Formatting.Indented);
            return result;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                       .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                       .Select(user => new
                       {
                           firstName = user.FirstName,
                           lastName = user.LastName,
                           soldProducts = user.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                           {
                               name = b.Name,
                               price = b.Price,
                               buyerFirstName = b.Buyer.FirstName,
                               buyerLastName = b.Buyer.LastName,

                           })
                           .ToList()
                       })
                       .OrderBy(x => x.lastName)
                       .ThenBy(x => x.firstName)
                       .ToArray();
            var result = JsonConvert.SerializeObject(users, Formatting.Indented);
            return result;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Select(product => new
                    {
                        name = product.Name,
                        price = product.Price,
                        seller = product.Seller.FirstName + " " + product.Seller.LastName
                    })
                    .OrderBy(x => x.price)
                    .ToArray();
            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            IEnumerable<UserInputModel> dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductImputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategory = JsonConvert
                                .DeserializeObject<IEnumerable<CategoryImputModel>>(inputJson)
                                .Where(c => c.Name != null)
                                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategory);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();
            var dtoCategotyProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategotyProducts);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }
        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}