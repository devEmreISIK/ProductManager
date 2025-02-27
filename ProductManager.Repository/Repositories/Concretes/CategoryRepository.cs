using ProductManager.Models.Entities;
using ProductManager.Repository.Contexts;
using ProductManager.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Concretes;

public sealed class CategoryRepository(BaseDbContext context) : ICategoryRepository
{
    public Category Add(Category entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdateDate = DateTime.UtcNow;
        context.Categories.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public Category Delete(Category entity)
    {
        context.Categories.Remove(entity);
        context.SaveChanges();
        return entity;
    }

    public bool ExistsByCategoryName(string categoryName)
    {
        return context.Categories.Any(x => x.CategoryName == categoryName);
    }

    public List<Category> GetAll()
    {
        return context.Categories.ToList();
    }

    public Category? GetById(int id)
    {
        return context.Categories.Find(id);
    }

    public Category Update(Category entity)
    {
        entity.UpdateDate = DateTime.UtcNow;
        context.Categories.Update(entity);
        context.SaveChanges();
        return entity;
    }
}
