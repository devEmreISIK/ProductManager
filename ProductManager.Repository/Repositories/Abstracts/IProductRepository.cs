using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Abstracts;

public interface IProductRepository : IRepository<Product, int>
{
    List<Product> GetAllByCategory(int categoryId);
    List<Product> GetAllByPriceRange(int min, int max);
    List<Product> GetAllByStockRange(int min, int max);
}
