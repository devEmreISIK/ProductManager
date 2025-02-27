using ProductManager.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Repository.Repositories.Abstracts;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    TEntity? GetById(TId id);
    List<TEntity> GetAll();
}
