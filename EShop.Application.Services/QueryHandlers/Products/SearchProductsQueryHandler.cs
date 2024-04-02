using EShop.Application.Abstractions.DTOs.Common;
using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Services.Extensions;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.Ordering;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Ordering;
using EShop.Domain.ProductAggregate.Ordering.Visitor;
using EShop.Domain.ProductAggregate.Specifications;
using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;
using MediatR;

namespace EShop.Application.Services.QueryHandlers.Products;

public class SearchProductsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<SearchProductsQuery, ListDto<ProductShortDto>>
{
    public async Task<ListDto<ProductShortDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        ISpecification<Product, IProductSpecificationVisitor> specification =
            new ProductByCategorySpecification(request.CategoryId);

        if (request.Query != null)
            specification = specification.AddToSpecification(new ProductByNameSpecification(request.Query));

        if (request.MinPrice.HasValue || request.MaxPrice.HasValue)
            specification =
                specification.AddToSpecification(new ProductByPriceSpecification(request.MinPrice, request.MaxPrice));

        if (request.Attributes != null)
        {
            foreach (var (key, value) in request.Attributes)
            {
                specification = specification.AddToSpecification(new ProductByAttributeSpecification(key, value));
            }
        }

        IOrderBy<Product, IProductSortingVisitor> order = request.Order switch
        {
            ProductOrder.Alphabet => new ProductOrderByAlphabet(),
            ProductOrder.AlphabetDesc => new DescendingOrder<Product, IProductSortingVisitor>(
                new ProductOrderByAlphabet()),
            ProductOrder.Price => new ProductOrderByPrice(),
            ProductOrder.PriceDesc => new DescendingOrder<Product, IProductSortingVisitor>(new ProductOrderByPrice()),
            _ => throw new ArgumentOutOfRangeException()
        };

        var products =
            await unitOfWork.ProductRepository.Value.FindAsync(specification, order, request.Skip, request.Take);

        return new ListDto<ProductShortDto>
        {
            List = products.Select(Map).ToArray(),
            TotalCount = await unitOfWork.ProductRepository.Value.CountAsync(specification)
        };
    }

    private static ProductShortDto Map(Product product) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl,
        Name = product.Name,
        Price = product.Price,
        Count = product.Count
    };
}