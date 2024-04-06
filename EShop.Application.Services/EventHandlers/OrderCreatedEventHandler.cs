using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.OrderAggregate.Events;
using EShop.Domain.ProductAggregate.Events;
using MediatR;

namespace EShop.Application.Services.EventHandlers;

public class OrderCreatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        foreach (var (product, count) in notification.Products)
        {
            product.Count -= count;
            await unitOfWork.ProductRepository.Value.UpdateAsync(product);
        }
    }
}