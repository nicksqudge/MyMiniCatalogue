using DragonScribeStudios.MyMiniCatalogue.Core;
using DragonScribeStudios.MyMiniCatalogue.Core.Data;

namespace DragonScribeStudios.MyMiniCatalogue.Games.Warhammer40k.Data;

public class GameSeed : DragonScribeStudios.MyMiniCatalogue.Core.Data.GameSeed
{
    public void Initialize(Database db)
    {
        var game = db.GamesTable.Add(new Game()
        {
            Code = "warhammer40k",
            Name = "Warhammer40k",
        }).Entity;

        var factions = new Faction[]
        {
            new ()
            {
                Code = "40k_necrons",
                Name = "Necrons",
                Game = game
            },
            new ()
            {
                Code = "40k_tyranids",
                Name = "Tyranids",
                Game = game
            },
            new ()
            {
                Code = "40k_orks",
                Name = "Orks",
                Game = game
            }
        };
        
        db.FactionsTable.AddRange(factions);
        db.SaveChanges();
    }
}