namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Models;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Position;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));



            this.CreateMap<Position, PositionsAllViewModel>()
               .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, EmployeeRegisterPositionsAvailable>()
                .ForMember(x=>x.PositionId, y=>y.MapFrom(s=>s.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));


            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>();
               
            this.CreateMap<ListAllCategoriesDto, CategoryAllViewModel>()
                .ForMember(x=>x.Name, y=>y.MapFrom(s=>s.CategoryName));
           
            this.CreateMap<CreateCategoryDto, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName)); 
            
            this.CreateMap<Category, CategoryAllViewModel>();

            this.CreateMap<Category, ListAllCategoriesDto>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name)); ;

            //Employees
            this.CreateMap<EmployeeRegisterPositionsAvailable, RegisterEmployeeViewModel>();

            this.CreateMap<RegisterEmployeeInputModel, RegisterEmployeeDto>();

            this.CreateMap<RegisterEmployeeDto, Employee>();

            this.CreateMap<ListAllEmployeesDto, EmployeesAllViewModel>();

            this.CreateMap<Employee, ListAllEmployeesDto>()
                .ForMember(x=>x.Position, y=>y.MapFrom(s=>s.Position.Name));




        }
    }
}
