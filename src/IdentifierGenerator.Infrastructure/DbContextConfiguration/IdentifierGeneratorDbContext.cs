using IdentifierGenerator.Infrastructure.DbContextConfiguration.Maps;
using IdentifierGenerator.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentifierGenerator.Infrastructure.DbContextConfiguration
{
    public class IdentifierGeneratorDbContext : DbContext
    {
        protected IdentifierGeneratorDbContext()
        { }

        public IdentifierGeneratorDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<Identifier> Identifier { get; set; } = null!;
        public DbSet<IdentifierGenerated> IdentifierGenerated { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdentifierMap());
            modelBuilder.ApplyConfiguration(new IdentifierGeneratedMap());
        }
    }
}
