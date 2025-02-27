using AutoMapper;
using ProductManager.Models.DTOs.Categories;
using ProductManager.Models.Entities;
using ProductManager.Repository.Repositories.Abstracts;
using ProductManager.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Service.Concretes;

public sealed class CategoryService(IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
{
    public void Add(CategoryAddRequestDto categoryAddRequestDto)
    {
        bool isPresent = categoryRepository.ExistsByCategoryName(categoryAddRequestDto.CategoryName);
        if (isPresent)
        {
            throw new Exception("Category name exists!");
        }
        Category category = mapper.Map<Category>(categoryAddRequestDto);
        categoryRepository.Add(category);
    }

    public void Delete(int id)
    {
        var category = categoryRepository.GetById(id);
        if (category is null)
        {
            throw new Exception("Category is null. Delete action.");
        }
        categoryRepository.Delete(category!);
    }

    public List<CategoryResponseDto> GetAllCategories()
    {
        var categories = categoryRepository.GetAll();
        var responses = mapper.Map<List<CategoryResponseDto>>(categories);
        return responses;
    }

    public CategoryResponseDto GetById(int id)
    {
        Category? category = categoryRepository.GetById(id);
        if (category is null)
        {
            throw new Exception("Category not found.");
        }
        CategoryResponseDto dto = mapper.Map<CategoryResponseDto>(category);
        return dto;
    }

    public void Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
    {
        Category category = mapper.Map<Category>(categoryUpdateRequestDto);
        categoryRepository.Update(category);
    }
}
