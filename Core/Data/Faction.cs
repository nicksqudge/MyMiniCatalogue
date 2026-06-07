using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Data;

public sealed record Faction
{
    public int Id { get; set; }
    public string Code { get; set; }
    public Game Game { get; set; }
    public string Name { get; set; }
}

public class FactionConfig : IEntityTypeConfiguration<Faction>
{
    public void Configure(EntityTypeBuilder<Faction> builder)
    {
        builder.ToDataTable("Factions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Code).IsCode();
        builder.HasOne(x => x.Game);
    }
}