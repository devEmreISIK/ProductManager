using Microsoft.EntityFrameworkCore;
using ProductManager.Models.Entities;
using ProductManager.Repository.Contexts;
using ProductManager.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Concretes;

public sealed class ProductRepository(BaseDbContext context) : IProductRepository
{
    public Product Add(Product entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdateDate = DateTime.UtcNow;
        context.Products.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public Product Delete(Product entity)
    {
        context.Products.Remove(entity);
        context.SaveChanges();
        return entity;
    }

    public List<Product> GetAll()
    {
        return context.Products.ToList();
    }

    public List<Product> GetByCategory(int categoryId)
    {
        return context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).ToList();
    }

    public Product? GetById(int id)
    {
        return context.Products.Find(id);
    }

    public List<Product> GetByPriceRange(int min, int max)
    {
        return context.Products.Where(p => p.Price < max && p.Price > min).Include(p => p.Category).ToList();
    }

    public List<Product> GetByStockRange(int min, int max)
    {
        return context.Products.Where(p => p.Stock < max && p.Stock > min).Include(p => p.Category).ToList();
    }

    public Product Update(Product entity)
    {
        entity.UpdateDate = DateTime.UtcNow;
        context.Products.Update(entity);
        context.SaveChanges();
        return entity;
    }
}
