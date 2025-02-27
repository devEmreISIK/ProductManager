using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models.Entities;

public abstract class Entity<TId>
{
    protected Entity()
    {

    }
    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
