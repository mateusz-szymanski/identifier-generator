using IdentifierGenerator.Application.Queries.IdentifiersForFactoryAndCategory;
using IdentifierGenerator.Infrastructure.DbContextConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.Infrastructure.Queries
{
    class IdentifiersForFactoryAndCategoryQueryHandler : IRequestHandler<IdentifiersForFactoryAndCategoryQuery,
        IdentifiersForFactoryAndCategoryQueryResponse>
    {
        private readonly IdentifierGeneratorDbContext _dbContext;

        public IdentifiersForFactoryAndCategoryQueryHandler(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _dbContext = identifierGeneratorDbContext;
        }

        public async Task<IdentifiersForFactoryAndCategoryQueryResponse> Handle(IdentifiersForFactoryAndCategoryQuery request, CancellationToken cancellationToken)
        {
            var identifiers = await (from ig in _dbContext.IdentifierGenerated
                                     join i in _dbContext.Identifier on ig.IdentifierGlobalId equals i.GlobalId
                                     where i.FactoryCode == request.FactoryCode && i.CategoryCode == request.CategoryCode
                                     orderby ig.GeneratedOn descending
                                     select new IdentifiersForFactoryAndCategoryReadModel
                                     {
                                         Code = ig.Code,
                                         CreatedOn = ig.GeneratedOn
                                     }).ToListAsync(cancellationToken);

            return new IdentifiersForFactoryAndCategoryQueryResponse(identifiers);
        }
    }
}
