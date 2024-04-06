using EShop.Application.Abstractions.Commands.Profile;
using EShop.Application.Abstractions.Exceptions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;

namespace EShop.Application.Services.CommandHandlers.Profile;

public class AddToShoppingCartCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddToShoppingCartCommand>
{
    public async Task Handle(AddToShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId);
        if (user == null) throw new UserNotFoundException();
        var product = await unitOfWork.ProductRepository.Value.GetAsync(request.ProductId);
        if (product == null) throw new ProductNotFoundException();
        user.AddToShoppingCart(product, request.Count);
        await unitOfWork.UserRepository.Value.UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();
    }
}