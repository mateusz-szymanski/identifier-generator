using IdentifierGenerator.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IdentifierGenerator.Infrastructure.DbContextConfiguration.Maps
{
    internal class IdentifierGeneratedMap : IEntityTypeConfiguration<IdentifierGenerated>
    {
        public void Configure(EntityTypeBuilder<IdentifierGenerated> builder)
        {
            builder.ToTable("IdentifierGenerated");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.IdentifierGlobalId);
            builder.Property(x => x.GeneratedOn)
                .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
        }
    }
}
