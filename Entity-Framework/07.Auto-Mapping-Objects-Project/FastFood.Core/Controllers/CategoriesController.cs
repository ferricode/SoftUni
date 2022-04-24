namespace FastFood.Core.Controllers
{
    using AutoMapper;
    using Data;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        //private readonly FastFoodContext context;
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }
            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);

            this.categoryService.Create(categoryDto);

            return this.RedirectToAction("All");
           
        }

        public IActionResult All()
        {
            ICollection<ListAllCategoriesDto> categoriesDto = this.categoryService.All();

            var categoryViewModels =this.mapper
                                     .Map<ICollection<ListAllCategoriesDto>, ICollection<CategoryAllViewModel>>(categoriesDto)
                                     .ToList();

            return this.View("All", categoryViewModels);

        }
    }
}
