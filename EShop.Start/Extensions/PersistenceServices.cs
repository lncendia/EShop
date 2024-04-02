using EShop.Application.Abstractions.Photos;
using EShop.Application.Storage;
using EShop.Application.Storage.Context;
using EShop.Application.Storage.Photos;
using EShop.Authentication.Storage.DbContexts;
using EShop.Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.Start.Extensions;

public static class PersistenceServices
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, string rootPath)
    {
        var application = configuration.GetRequiredValue<string>("ConnectionStrings:Application");
        var authentication = configuration.GetRequiredValue<string>("ConnectionStrings:Authentication");
        
        var contentPath = configuration.GetRequiredValue<string>("Thumbnails");

        services.AddDbContext<AuthenticationDbContext>(options =>
        {
            options.UseNpgsql(authentication, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(application, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IPhotoStore, PhotoStore>(_ => new PhotoStore(rootPath, contentPath));
    }
}