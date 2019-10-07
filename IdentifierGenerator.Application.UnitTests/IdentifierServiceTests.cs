using IdentifierGenerator.Infrastructure;
using IdentifierGenerator.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace IdentifierGenerator.Application.UnitTests
{
    public class IdentifierServiceTests
    {
        [Fact]
        public void IdentifierServiceShouldReturnProperCodeForNewlyCreatedFactoryAndService()
        {
            var dbContextOptions = new DbContextOptionsBuilder<IdentifierGeneratorDbContext>()
                .UseInMemoryDatabase($"IdentifierDb-{Guid.NewGuid().ToString()}")
                .Options;

            using (var dbContext = new IdentifierGeneratorDbContext(dbContextOptions))
            {
                var identifierRepository = new IdentifierRepository(dbContext);
                var identifierService = new IdentifierService(identifierRepository);

                var code = identifierService.GenerateCodeFor("F001", "C001");

                Assert.Equal("C001-F001-1", code);
            }
        }

        [Fact]
        public void IdentifierServiceShouldReturnProperCodeForAlreadyExistingFactoryAndService()
        {
            var dbContextOptions = new DbContextOptionsBuilder<IdentifierGeneratorDbContext>()
                .UseInMemoryDatabase($"IdentifierDb-{Guid.NewGuid().ToString()}")
                .Options;

            using (var dbContext = new IdentifierGeneratorDbContext(dbContextOptions))
            {
                dbContext.Identifier.Add(new Identifier("F001", "C001"));
                dbContext.SaveChanges();
            }

            using (var dbContext = new IdentifierGeneratorDbContext(dbContextOptions))
            {
                var identifierRepository = new IdentifierRepository(dbContext);
                var identifierService = new IdentifierService(identifierRepository);

                var code = identifierService.GenerateCodeFor("F001", "C001");

                Assert.Equal("C001-F001-1", code);
            }
        }
    }
}
