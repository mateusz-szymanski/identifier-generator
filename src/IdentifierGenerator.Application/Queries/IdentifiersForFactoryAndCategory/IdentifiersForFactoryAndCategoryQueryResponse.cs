using System.Collections.Generic;

namespace IdentifierGenerator.Application.Queries.IdentifiersForFactoryAndCategory
{
    public class IdentifiersForFactoryAndCategoryQueryResponse
    {
        public IEnumerable<IdentifiersForFactoryAndCategoryReadModel> Identifiers { get; private set; }

        public IdentifiersForFactoryAndCategoryQueryResponse(IEnumerable<IdentifiersForFactoryAndCategoryReadModel> identifiers)
        {
            Identifiers = identifiers;
        }
    }
}
