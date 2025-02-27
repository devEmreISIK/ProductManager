using ProductManager.Models.DTOs.Categories;
using ProductManager.Models.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Service.Abstracts;

public interface IProductService
{
    void Add(ProductAddRequestDto productAddRequestDto);
    void Update(ProductUpdateRequestDto productUpdateRequestDto);
    List<ProductResponseDto> GetAllProducts();
    void Delete(int id);
    ProductResponseDto GetById(int id);
    List<ProductResponseDto> GetAllByPriceRange(int max, int min);
    List<ProductResponseDto> GetAllByStockRange(int max, int min);
    List<ProductResponseDto> GetAllByCategory(int categotyId);

}
