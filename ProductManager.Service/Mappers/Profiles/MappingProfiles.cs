using AutoMapper;
using ProductManager.Models.DTOs.Categories;
using ProductManager.Models.DTOs.Products;
using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Service.Mappers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<CategoryAddRequestDto, Category>();
        CreateMap<CategoryUpdateRequestDto, Category>();

        CreateMap<Product, ProductResponseDto>();
        CreateMap<ProductAddRequestDto, Product>();
        CreateMap<ProductUpdateRequestDto, Product>();

       
    }
}
