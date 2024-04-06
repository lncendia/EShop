using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.OrderAggregate.Events;
using EShop.Domain.ProductAggregate.Specifications;
using MediatR;

namespace EShop.Application.Services.EventHandlers;

public class OrderCanceledEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<OrderCanceledEvent>
{
    public async Task Handle(OrderCanceledEvent notification, CancellationToken cancellationToken)
    {
        var specification = new ProductByIdsSpecification(notification.Products.Select(p => p.product).ToArray());
        var products = await unitOfWork.ProductRepository.Value.FindAsync(specification);

        foreach (var (id, count) in notification.Products)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) continue;
            product.Count += count;
            await unitOfWork.ProductRepository.Value.UpdateAsync(product);
        }
    }
}