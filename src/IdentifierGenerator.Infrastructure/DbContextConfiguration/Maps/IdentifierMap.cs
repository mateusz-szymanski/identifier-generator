using IdentifierGenerator.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentifierGenerator.Infrastructure.DbContextConfiguration.Maps
{
    class IdentifierMap : IEntityTypeConfiguration<Identifier>
    {
        public void Configure(EntityTypeBuilder<Identifier> builder)
        {
            builder.ToTable("Identifier");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.GlobalId).IsUnique();
            builder.Property(x => x.CategoryCode).HasMaxLength(30);
            builder.Property(x => x.FactoryCode).HasMaxLength(30);
            builder.HasIndex(x => new { x.FactoryCode, x.CategoryCode });
            builder.Property(x => x.Value).IsConcurrencyToken();
        }
    }
}
