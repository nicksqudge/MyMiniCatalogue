using DragonScribeStudios.MyMiniCatalogue.Core.Data;
using DragonScribeStudios.MyMiniCatalogue.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DragonScribeStudios.MyMiniCatalogue.Controllers;

[Route("api/cache")]
[ApiController]
public class CacheController(GameQuery gameQuery, FactionQuery factionQuery) : Controller
{
    public sealed record CacheResult
    {
        public Game Game { get; init; }
        public Faction[] Factions { get; init; }
    }

    [HttpGet]
    public async Task<ActionResult<CacheResult>> Get(CancellationToken cancellationToken)
    {
        var game = await gameQuery.Get(cancellationToken);
        var result = new CacheResult()
        {
            Game = game,
            Factions = await factionQuery.Get(game.GameId(), cancellationToken)
        };
        return Ok(result);
    }
}