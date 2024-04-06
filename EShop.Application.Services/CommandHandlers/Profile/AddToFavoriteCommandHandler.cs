using EShop.Application.Abstractions.Commands.Profile;
using EShop.Application.Abstractions.Exceptions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;

namespace EShop.Application.Services.CommandHandlers.Profile;

public class AddToFavoriteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddToFavoriteCommand>
{
    public async Task Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId);
        if (user == null) throw new UserNotFoundException();
        var product = await unitOfWork.ProductRepository.Value.GetAsync(request.ProductId);
        if (product == null) throw new ProductNotFoundException();
        user.AddToFavorite(product);
        await unitOfWork.UserRepository.Value.UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();
    }
}