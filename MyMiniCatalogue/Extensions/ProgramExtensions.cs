using DragonScribeStudios.MyMiniCatalogue.Core;
using DragonScribeStudios.MyMiniCatalogue.Core.Data;

namespace DragonScribeStudios.MyMiniCatalogue.Extensions;

public static class ProgramExtensions
{
    public static void SeedDatabaseWithGames(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            var seeds = scope.ServiceProvider.GetServices<GameSeed>();
            if (!seeds.Any())
            {
                logger.LogInformation("No game seeds found");
                return;
            }

            logger.LogDebug("{seedCount} seeds found", seeds.Count());
            var db = scope.ServiceProvider.GetRequiredService<Database>();
            if (db.Database.EnsureCreated())
            {
                foreach (var seed in seeds)
                {
                    logger.LogInformation("Running game seed: {name}", seeds.GetType().FullName);
                    seed.Initialize(db);
                }
            }
        }
    }
}