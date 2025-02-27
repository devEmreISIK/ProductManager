namespace ProductManager.Models.DTOs.Products;

public sealed record ProductUpdateRequestDto(
    int Id,
    string ProductName,
    double Price,
    int Stock,
    int CategoryId
    );
