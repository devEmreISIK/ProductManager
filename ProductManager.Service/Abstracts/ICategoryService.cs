using ProductManager.Models.DTOs.Categories;
using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Service.Abstracts;

public interface ICategoryService
{
    void Add(CategoryAddRequestDto categoryAddRequestDto);
    void Update(CategoryUpdateRequestDto categoryUpdateRequestDto);
    List<CategoryResponseDto> GetAllCategories();
    void Delete(int id);
    CategoryResponseDto GetById(int id);

}
