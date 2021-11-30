using AutoMapper;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductImputModel, Product>();
            this.CreateMap<CategoryImputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();

        }
    }
}
