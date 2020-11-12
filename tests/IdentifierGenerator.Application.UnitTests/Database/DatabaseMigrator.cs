using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using System;
using System.Threading.Tasks;

namespace IdentifierGenerator.Application.UnitTests.Database
{
    public sealed class DatabaseMigrator : IAsyncDisposable
    {
        private readonly IdentifierGeneratorDbContext _identifierGeneratorDbContext;

        public DatabaseMigrator(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _identifierGeneratorDbContext = identifierGeneratorDbContext;
        }

        public async Task EnsureCreated()
        {
            await _identifierGeneratorDbContext.Database.EnsureCreatedAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _identifierGeneratorDbContext.Database.EnsureDeletedAsync();
        }
    }
}
