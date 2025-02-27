using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Abstracts;

public interface IProductRepository : IRepository<Product, int>
{
    List<Product> GetByCategory(int categoryId);
    List<Product> GetByPriceRange(int min, int max);
    List<Product> GetByStockRange(int min, int max);
}
