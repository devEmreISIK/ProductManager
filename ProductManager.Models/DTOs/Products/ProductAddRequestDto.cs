using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Models.DTOs.Products;

public sealed record ProductAddRequestDto(
    string ProductName,
    double Price,
    int Stock,
    int CategoryId
    );
