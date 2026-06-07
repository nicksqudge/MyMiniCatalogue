using DragonScribeStudios.MyMiniCatalogue.Controllers;

namespace DragonScribeStudios.MyMiniCatalogue.Services;

public class CacheState(Api api)
{
    public CacheController.CacheResult? Cache { get; private set; }

    public async Task Load()
    {
        Cache = await api.GetCache(CancellationToken.None);
    }
}