using EShop.Application.Abstractions.Commands.Categories;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.CategoryAggregate;
using MediatR;

namespace EShop.Application.Services.CommandHandlers.Categories;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Attributes)
        {
            Name = request.Name
        };

        await unitOfWork.CategoryRepository.Value.AddAsync(category);
        await unitOfWork.SaveChangesAsync();
        return category.Id;
    }
}