using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
    bool ExistsByCategoryName(string categoryName);
}
