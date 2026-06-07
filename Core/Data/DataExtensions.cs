using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DragonScribeStudios.MyMiniCatalogue.Core.Data;

public static class DataExtensions
{
    public static void ToDataTable<T>(this EntityTypeBuilder<T> builder, string tableName) where T : class
    {
        builder.ToTable(tableName, "Data");
    }

    public static void IsCode(this PropertyBuilder<string> property)
    {
        property.IsRequired().HasMaxLength(30);
    }
}