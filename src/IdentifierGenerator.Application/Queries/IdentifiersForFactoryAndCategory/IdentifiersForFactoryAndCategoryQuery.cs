using MediatR;

namespace IdentifierGenerator.Application.Queries.IdentifiersForFactoryAndCategory
{
    public class IdentifiersForFactoryAndCategoryQuery : IRequest<IdentifiersForFactoryAndCategoryQueryResponse>
    {
        public string FactoryCode { get; private set; }
        public string CategoryCode { get; private set; }

        public IdentifiersForFactoryAndCategoryQuery(string factoryCode, string categoryCode)
        {
            FactoryCode = factoryCode;
            CategoryCode = categoryCode;
        }
    }
}
