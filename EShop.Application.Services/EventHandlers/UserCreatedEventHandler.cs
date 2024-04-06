using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.UserAggregate;
using EShop.IntegrationEvents;
using MediatR;

namespace EShop.Application.Services.EventHandlers;

public class UserCreatedEventHandler(IUnitOfWork unitOfWork) : INotificationHandler<UserCreatedIntegrationEvent>
{
    public async Task Handle(UserCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var user = new User(notification.Id);
        await unitOfWork.UserRepository.Value.AddAsync(user);
        await unitOfWork.SaveChangesAsync();
    }
}