using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.ProductAggregate.Events;
using MediatR;

namespace EShop.Application.Services.EventHandlers;

public class NewProductEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<NewProductEvent>
{
    public async Task Handle(NewProductEvent notification, CancellationToken cancellationToken)
    {
        notification.Category.UpdateAttributes(notification.Product);
        await unitOfWork.CategoryRepository.Value.UpdateAsync(notification.Category);
    }
}