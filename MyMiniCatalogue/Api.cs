using DragonScribeStudios.MyMiniCatalogue.Controllers;
using Microsoft.AspNetCore.Components;

namespace DragonScribeStudios.MyMiniCatalogue;

public class Api(HttpClient client, NavigationManager navigationManager)
{
    private string Url => navigationManager.BaseUri + "api/";
    
    public Task<CacheController.CacheResult?> GetCache(CancellationToken cancellationToken)
     => client.GetFromJsonAsync<CacheController.CacheResult>(Url + "cache", cancellationToken);
}