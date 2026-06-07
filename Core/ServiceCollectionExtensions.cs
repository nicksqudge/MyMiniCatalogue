using DragonScribeStudios.MyMiniCatalogue.Core.Data;
using DragonScribeStudios.MyMiniCatalogue.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DragonScribeStudios.MyMiniCatalogue.Core;

public static class ServiceCollectionExtensions
{
    public static void AddMyMiniCatalogueCore(this IServiceCollection services)
    {
        services.AddSqlite<Database>("Data Source=myminicatalogue.db");        
        services.AddTransient<GameQuery, GameQueryImplementation>();
        services.AddTransient<FactionQuery, FactionQueryImplementation>();
    }

    public static void AddGameSeed<T>(this IServiceCollection services) where T : class, GameSeed
    {
        services.AddTransient<GameSeed, T>();
    }
}