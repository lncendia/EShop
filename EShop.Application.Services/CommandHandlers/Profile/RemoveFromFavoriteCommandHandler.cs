using EShop.Application.Abstractions.Commands.Profile;
using EShop.Application.Abstractions.Exceptions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;

namespace EShop.Application.Services.CommandHandlers.Profile;

public class RemoveFromFavoriteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RemoveFromFavoriteCommand>
{
    public async Task Handle(RemoveFromFavoriteCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId);
        if (user == null) throw new UserNotFoundException();
        user.RemoveFromFavorite(request.ProductId);
        await unitOfWork.UserRepository.Value.UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();
    }
}