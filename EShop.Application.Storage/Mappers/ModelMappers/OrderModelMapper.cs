using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Order;
using EShop.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Mappers.ModelMappers;

internal class OrderModelMapper(ApplicationDbContext context) : IModelMapperUnit<OrderModel, Order>
{
    public async Task<OrderModel> MapAsync(Order aggregate)
    {
        var model = await context.Orders
                        .LoadDependencies()
                        .FirstOrDefaultAsync(x => x.Id == aggregate.Id) ??
                    new OrderModel { Id = aggregate.Id };

        model.Message = aggregate.Message;
        model.CreationTime = aggregate.CreationTime;
        model.IsCompleted = aggregate.IsCompleted;
        model.IsSucceeded = aggregate.IsSucceeded;
        model.TotalPrice = aggregate.TotalPrice;
        model.UserId = aggregate.UserId;
        model.CustomerInfo = new CustomerModel
        {
            Name = aggregate.CustomerInfo.Name,
            PhoneNumber = aggregate.CustomerInfo.PhoneNumber,
            Email = aggregate.CustomerInfo.Email
        };
        model.DeliveryInfo = new DeliveryModel
        {
            Region = aggregate.DeliveryInfo.Region,
            City = aggregate.DeliveryInfo.City,
            Street = aggregate.DeliveryInfo.Street,
            Building = aggregate.DeliveryInfo.Building,
            Apartment = aggregate.DeliveryInfo.Apartment,
            Comment = aggregate.DeliveryInfo.Comment,
            Flat = aggregate.DeliveryInfo.Flat
        };

        ProcessOrderItems(aggregate, model);

        return model;
    }

    private static void ProcessOrderItems(Order aggregate, OrderModel model)
    {
        model.OrderItems.RemoveAll(uh => aggregate.OrderItems.All(eh => eh.Id != uh.ProductId));

        var orderItemsToAdd = aggregate.OrderItems
            .Where(eh => model.OrderItems.All(uh => uh.ProductId != eh.Id))
            .Select(eh => new OrderItemModel
            {
                ProductId = eh.Id,
                Count = eh.Count
            });

        foreach (var value in model.OrderItems)
        {
            value.Count = aggregate.OrderItems.First(i => i.Id == value.ProductId).Count;
        }

        model.OrderItems.AddRange(orderItemsToAdd);
    }
}