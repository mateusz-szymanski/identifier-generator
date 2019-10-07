using IdentifierGenerator.Domain;
using IdentifierGenerator.Model.Domain;

namespace IdentifierGenerator.Application
{
    public class IdentifierService : IIdentifierService
    {
        private readonly IIdentifierRepository _identifierRepository;

        public IdentifierService(IIdentifierRepository identifierRepository)
        {
            _identifierRepository = identifierRepository;
        }

        public string GenerateCodeFor(string factoryCode, string categoryCode)
        {
            var identifier = _identifierRepository.GetIdentifierFor(factoryCode, categoryCode);

            if (identifier == null)
            {
                identifier = new Identifier(factoryCode, categoryCode);
                _identifierRepository.Add(identifier);
            }

            var identifierGenerated = identifier.MoveToNextValue();

            _identifierRepository.Add(identifierGenerated);
            _identifierRepository.SaveChanges();

            return identifierGenerated.Code;
        }
    }
}
