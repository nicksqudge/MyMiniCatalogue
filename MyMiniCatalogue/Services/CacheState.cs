using DragonScribeStudios.MyMiniCatalogue.Core.Data;

namespace DragonScribeStudios.MyMiniCatalogue.Services;

public class CacheState(Api api)
{
    public Game? Game { get; private set; }
    public Faction[]? Factions { get; private set; }

    public async Task Load()
    {
        var result = await api.GetCache(CancellationToken.None);
        Game = result?.Game;
        Factions = result?.Factions;
    }
}