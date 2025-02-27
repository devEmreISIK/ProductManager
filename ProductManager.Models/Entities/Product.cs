using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models.Entities;

public class Product : Entity<int>
{
    [Required(ErrorMessage = "Please enter a product name!")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Please enter a product price!")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero!")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Please enter a product stock!")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative!")]
    public int Stock { get; set; }



    [Required(ErrorMessage = "Please select a category name!")]
    public int CategoryId { get; set; }

    [ValidateNever]
    public Category Category { get; set; }
}
