using AutoMapper;
using ProductManager.Models.DTOs.Products;
using ProductManager.Models.Entities;
using ProductManager.Repository.Repositories.Abstracts;
using ProductManager.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Service.Concretes;

public class ProductService(IMapper mapper, IProductRepository productRepository) : IProductService
{
    public void Add(ProductAddRequestDto productAddRequestDto)
    {
        Product product = mapper.Map<Product>(productAddRequestDto);
        productRepository.Add(product);
    }

    public void Delete(int id)
    {
        Product? product = productRepository.GetById(id);
        if (product is null)
        {
            throw new Exception("Product not found. Delete action.");
        }
        productRepository.Delete(product!);
    }

    public List<ProductResponseDto> GetAllByCategory(int categotyId)
    {
        var products = productRepository.GetAllByCategory(categotyId);
        var responses =  mapper.Map<List<ProductResponseDto>>(products);
        return responses;
    }

    public List<ProductResponseDto> GetAllByPriceRange(int max, int min)
    {
        if (min<0 && max<0 && min>max)
        {
            throw new Exception("Invalid range!");
        }
        var products = productRepository.GetAllByPriceRange(max, min);
        var responses = mapper.Map<List<ProductResponseDto>>(products);
        return responses;
    }

    public List<ProductResponseDto> GetAllByStockRange(int max, int min)
    {
        if (min < 0 && max < 0 && min > max)
        {
            throw new Exception("Invalid range!");
        }
        var products = productRepository.GetAllByStockRange(max, min);
        var responses = mapper.Map<List<ProductResponseDto>>(products);
        return responses;
    }

    public List<ProductResponseDto> GetAllProducts()
    {
        List<Product> products = productRepository.GetAll();
        List<ProductResponseDto> productResponseDtos = mapper.Map<List<ProductResponseDto>>(products);
        return productResponseDtos;
    }

    public ProductResponseDto GetById(int id)
    {
        var product = productRepository.GetById(id);
        if (product is null)
        {
            throw new Exception("Product not found.");
        }
        var response = mapper.Map<ProductResponseDto>(product);
        return response;
    }

    public void Update(ProductUpdateRequestDto productUpdateRequestDto)
    {
        Product product = mapper.Map<Product>(productUpdateRequestDto);
        productRepository.Update(product);
    }
}
