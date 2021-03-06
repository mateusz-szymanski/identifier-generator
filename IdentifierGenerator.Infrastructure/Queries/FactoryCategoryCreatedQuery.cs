﻿using System.Linq;

namespace IdentifierGenerator.Infrastructure.Queries
{
    public class AllIdentifierQuery
    {
        private readonly IdentifierGeneratorDbContext _dbContext;

        public AllIdentifierQuery(IdentifierGeneratorDbContext identifierGeneratorDbContext)
        {
            _dbContext = identifierGeneratorDbContext;
        }

        public dynamic Get()
        {
            return (from i in _dbContext.Identifier
                    orderby i.FactoryCode, i.CategoryCode
                    select new
                    {
                        i.FactoryCode,
                        i.CategoryCode,
                        i.Value
                    }).ToList();
        }
    }
}
