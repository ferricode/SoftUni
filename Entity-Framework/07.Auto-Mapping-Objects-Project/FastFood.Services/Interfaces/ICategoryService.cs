using FastFood.Services.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDto dto);
        ICollection<ListAllCategoriesDto> All();
    }
}
