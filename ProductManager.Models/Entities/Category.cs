using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models.Entities;

public class Category : Entity<int>
{
    public Category()
    {
        CategoryName = string.Empty;
        Products = new List<Product>();
    }

    [Required(ErrorMessage = "Please enter a category name!")]
    public string CategoryName { get; set; }

    public List<Product> Products { get; set; }

}
