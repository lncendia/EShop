using System.Reflection;
using System.Runtime.CompilerServices;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Mappers.StaticMethods;
using EShop.Application.Storage.Models.Order;
using EShop.Domain.Abstractions;
using EShop.Domain.OrderAggregate;
using EShop.Domain.OrderAggregate.ValueObjects;

namespace EShop.Application.Storage.Mappers.AggregateMappers;

internal class OrderMapper : IAggregateMapperUnit<Order, OrderModel>
{
    private static readonly Type OrderType = typeof(Order);

    private static readonly FieldInfo CustomerInfo =
        OrderType.GetField("<CustomerInfo>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo DeliveryInfo =
        OrderType.GetField("<DeliveryInfo>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo UserId =
        OrderType.GetField("<UserId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo OrderItems =
        OrderType.GetField("<OrderItems>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;

    public Order Map(OrderModel model)
    {
        var customerInfo = new CustomerInfo
        {
            Name = model.CustomerInfo.Name,
            PhoneNumber = model.CustomerInfo.PhoneNumber,
            Email = model.CustomerInfo.Email
        };
        var deliveryInfo = new DeliveryInfo
        {
            Region = model.DeliveryInfo.Region,
            City = model.DeliveryInfo.City,
            Street = model.DeliveryInfo.Street,
            Building = model.DeliveryInfo.Building
        };

        var order = (Order)RuntimeHelpers.GetUninitializedObject(OrderType);
        UserId.SetValue(order, model.UserId);
        DeliveryInfo.SetValue(order, deliveryInfo);
        CustomerInfo.SetValue(order, customerInfo);
        OrderItems.SetValue(order,
            model.OrderItems.Select(i => new ProductInfo { Count = i.Count, Id = i.ProductId }).ToArray());

        IdFields.DomainEvents.SetValue(order, new List<IDomainEvent>());
        IdFields.AggregateId.SetValue(order, model.Id);
        return order;
    }
}