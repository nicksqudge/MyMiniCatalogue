using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Data;

public sealed record Faction
{
    public string Id { get; set; }
    public Game Game { get; set; }
    public string Name { get; set; }
}

public class FactionConfig : IEntityTypeConfiguration<Faction>
{
    public void Configure(EntityTypeBuilder<Faction> builder)
    {
        builder.ToDataTable("Factions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasOne(x => x.Game).WithMany(x => x.Factions);
    }
}