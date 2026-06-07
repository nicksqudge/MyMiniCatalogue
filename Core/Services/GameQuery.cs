using DragonScribeStudios.MyMiniCatalogue.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Services;

public interface GameQuery
{
    Task<Game> Get(CancellationToken cancellationToken);
}

public class GameQueryImplementation(Database database) : GameQuery
{
    public Task<Game> Get(CancellationToken cancellationToken)
    {
        return database.GamesTable.FirstAsync(cancellationToken);
    }
}