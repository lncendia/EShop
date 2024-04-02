using EShop.Domain.Abstractions;

namespace EShop.Application.Storage.Mappers.Abstractions;

public interface IModelMapperUnit<TModel, in TAggregate> where TAggregate : AggregateRoot
{
    Task<TModel> MapAsync(TAggregate model);
}