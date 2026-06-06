using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Data;

public sealed record Game
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Faction> Factions { get; set; }
}

public class GameConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToDataTable("Games");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}