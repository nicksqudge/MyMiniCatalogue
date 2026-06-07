using DragonScribeStudios.MyMiniCatalogue.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Services;

public interface FactionQuery
{
    Task<Faction[]> Get(GameId id, CancellationToken cancellationToken = default);
}

public class FactionQueryImplementation(Database database) : FactionQuery
{
    public Task<Faction[]> Get(GameId id, CancellationToken cancellationToken)
        => database.FactionsTable.Where(faction => faction.Game.Id == id.Value).OrderBy(faction => faction.Name).ToArrayAsync(cancellationToken);
}

