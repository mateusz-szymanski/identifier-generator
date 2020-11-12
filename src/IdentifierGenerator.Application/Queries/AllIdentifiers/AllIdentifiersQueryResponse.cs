using System.Collections.Generic;

namespace IdentifierGenerator.Application.Queries.AllIdentifiers
{
    public class AllIdentifiersQueryResponse
    {
        public IEnumerable<IdentifierReadModel> Identifiers { get; private set; }

        public AllIdentifiersQueryResponse(IEnumerable<IdentifierReadModel> identifiers)
        {
            Identifiers = identifiers;
        }
    }
}
