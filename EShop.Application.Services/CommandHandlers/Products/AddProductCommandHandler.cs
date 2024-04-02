﻿using EShop.Application.Abstractions.Commands.Products;
using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Photos;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.ProductAggregate;
using MediatR;

namespace EShop.Application.Services.CommandHandlers.Products;

public class AddProductCommandHandler(IUnitOfWork unitOfWork, IPhotoStore store)
    : IRequestHandler<AddProductCommand, Guid>
{
    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.Value.GetAsync(request.CategoryId);
        if (category == null) throw new CategoryNotFoundException();

        Uri? photo;
        if (request.PhotoUrl != null) photo = await store.SaveAsync(request.PhotoUrl);
        else if (request.PhotoBase64 != null) photo = await store.SaveAsync(request.PhotoBase64);
        else throw new PhotoMissingException();

        try
        {
            var product = new Product(category, request.Attributes)
            {
                PhotoUrl = photo,
                Name = request.Name,
                Price = request.Price,
            };

            await unitOfWork.ProductRepository.Value.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return product.Id;
        }
        catch(Exception)
        {
            await store.DeleteAsync(photo);
            throw;
        }
    }
}