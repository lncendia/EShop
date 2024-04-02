using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;

namespace EShop.Application.Services.QueryHandlers.Products;

public class ProductByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<ProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.ProductRepository.Value.GetAsync(request.Id);
        if (product == null) throw new ProductNotFoundException();
        
        return new ProductDto
        {
            Id = product.Id,
            PhotoUrl = product.PhotoUrl,
            Name = product.Name,
            Price = product.Price,
            Attributes = product.Attributes,
            CategoryId = product.CategoryId,
            Count = product.Count
        };
    }
}