namespace ProductManager.Models.DTOs.Products;

public sealed record ProductResponseDto(
    int Id,
    string ProductName,
    double Price,
    int Stock,
    int CategoryId
    );
