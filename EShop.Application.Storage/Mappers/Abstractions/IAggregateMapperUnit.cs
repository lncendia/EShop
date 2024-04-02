using EShop.Domain.Abstractions;

namespace EShop.Application.Storage.Mappers.Abstractions;

public interface IAggregateMapperUnit<out TAggregate, in TModel> where TAggregate : AggregateRoot
{
    TAggregate Map(TModel model);
}