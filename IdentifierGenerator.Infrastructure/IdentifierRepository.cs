using IdentifierGenerator.Domain;
using IdentifierGenerator.Model.Domain;
using System.Linq;

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

        public Identifier GetIdentifierFor(string factoryCode, string categoryCode)
        {
            var result = (from identifier in _dbContext.Identifier
                          where identifier.FactoryCode == factoryCode && identifier.CategoryCode == categoryCode
                          select identifier).SingleOrDefault();

            return result;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
