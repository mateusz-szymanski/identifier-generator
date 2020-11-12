using IdentifierGenerator.Application.Queries.AllIdentifiers;
using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.Infrastructure.Queries
{
    public class AllIdentifiersQueryHandler : IRequestHandler<AllIdentifiersQuery, AllIdentifiersQueryResponse>
    {
        private readonly IdentifierGeneratorDbContext _dbContext;

        public AllIdentifiersQueryHandler(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _dbContext = identifierGeneratorDbContext;
        }

        public async Task<AllIdentifiersQueryResponse> Handle(AllIdentifiersQuery request, CancellationToken cancellationToken)
        {
            var identifiers = await (from i in _dbContext.Identifier
                                     orderby i.FactoryCode, i.CategoryCode
                                     select new IdentifierReadModel()
                                     {
                                         FactoryCode = i.FactoryCode,
                                         CategoryCode = i.CategoryCode,
                                         Value = i.Value
                                     }).ToListAsync();

            return new AllIdentifiersQueryResponse(identifiers);
        }
    }
}
