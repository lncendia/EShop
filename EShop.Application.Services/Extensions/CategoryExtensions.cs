using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.CategoryAggregate;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.Extensions;

internal static class CategoryExtensions
{
    public static async Task<IReadOnlyCollection<Category>> TryGetCategoriesFromCacheAsync(this IMemoryCache memoryCache, IUnitOfWork unitOfWork)
    {
        // Проверяем, есть ли фильм в кэше 
        if (memoryCache.TryGetValue("categories", out IReadOnlyCollection<Category>? categories)) return categories!;
        
        // Если фильм не найден в кэше, получаем его из репозитория
        categories = await unitOfWork.CategoryRepository.Value.FindAsync(null);

        // Добавляем фильм в кэш с временем жизни 5 минут 
        memoryCache.Set("categories", categories, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));

        // Возвращаем найденный фильм 
        return categories;
    }
}