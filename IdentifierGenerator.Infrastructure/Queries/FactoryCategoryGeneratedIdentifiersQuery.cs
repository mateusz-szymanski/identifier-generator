using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IdentifierGenerator.Infrastructure.Queries
{
    public class FactoryCategoryGeneratedIdentifiersQuery
    {
        private IdentifierGeneratorDbContext _dbContext;

        public FactoryCategoryGeneratedIdentifiersQuery(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _dbContext = identifierGeneratorDbContext;
        }

        public IEnumerable<FactoryCategoryIdentifierGenerationViewModel> Get(string factory, string category)
        {
            return (from ig in _dbContext.IdentifierGenerated
                    join i in _dbContext.Identifier on ig.IdentifierGlobalId equals i.GlobalId
                    where i.FactoryCode == factory && i.CategoryCode == category
                    orderby ig.GeneratedOn descending
                    select new FactoryCategoryIdentifierGenerationViewModel
                    {
                        Code = ig.Code,
                        CreatedOn = ig.GeneratedOn
                    }).ToList();
        }
    }
}
