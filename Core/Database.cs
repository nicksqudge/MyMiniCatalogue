using DragonScribeStudios.MyMiniCatalogue.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DragonScribeStudios.MyMiniCatalogue.Core;

public class Database : DbContext
{
    public Database(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Game> GamesTable { get; set; }
}