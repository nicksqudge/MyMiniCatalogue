using DragonScribeStudios.MyMiniCatalogue.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DragonScribeStudios.MyMiniCatalogue.Games.Warhammer40k;

public static class ServiceCollectionExtensions
{
    public static void AddWarhammer40k(this IServiceCollection services)
    {
        services.AddGameSeed<Data.GameSeed>();
    }
}