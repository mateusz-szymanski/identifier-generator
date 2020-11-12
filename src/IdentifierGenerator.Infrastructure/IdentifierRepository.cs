using IdentifierGenerator.Domain;
using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using IdentifierGenerator.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.Infrastructure
{
    public class IdentifierRepository : IIdentifierRepository
    {
        private readonly IdentifierGeneratorDbContext _dbContext;

        public IdentifierRepository(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _dbContext = identifierGeneratorDbContext;
        }

        public void Add(Identifier identifier)
        {
            _dbContext.Identifier.Add(identifier);
        }

        public void Add(IdentifierGenerated identifierGenerated)
        {
            _dbContext.IdentifierGenerated.Add(identifierGenerated);
        }

        public async Task<Identifier> GetIdentifierFor(string factoryCode, string categoryCode, CancellationToken cancellationToken)
        {
            var result = await (from identifier in _dbContext.Identifier
                                where identifier.FactoryCode == factoryCode && identifier.CategoryCode == categoryCode
                                select identifier).SingleOrDefaultAsync(cancellationToken);

            return result;
        }

        public Task SaveChanges(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
