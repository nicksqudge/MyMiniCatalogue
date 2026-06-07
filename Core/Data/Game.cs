using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Data;

public sealed record Game
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public GameId GameId() => new(Id);
}

public sealed record GameId(int Value);

public class GameConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToDataTable("Games");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).IsCode();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
    }
}