using IdentifierGenerator.Domain;
using IdentifierGenerator.Model.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.Application.Commands
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Dependency injection")]
    class GenerateCodeCommandHandler : IRequestHandler<GenerateCodeCommand, GenerateCodeCommandResponse>
    {
        private readonly IIdentifierRepository _identifierRepository;

        public GenerateCodeCommandHandler(IIdentifierRepository identifierRepository)
        {
            _identifierRepository = identifierRepository;
        }

        public async Task<GenerateCodeCommandResponse> Handle(GenerateCodeCommand request, CancellationToken cancellationToken)
        {
            var identifier = await _identifierRepository.GetIdentifierFor(request.FactoryCode, request.CategoryCode, cancellationToken);

            if (identifier is null)
            {
                identifier = new Identifier(request.FactoryCode, request.CategoryCode);
                _identifierRepository.Add(identifier);
            }

            var identifierGenerated = identifier.IncrementValue();

            _identifierRepository.Add(identifierGenerated);
            await _identifierRepository.SaveChanges(cancellationToken);

            return new GenerateCodeCommandResponse(identifierGenerated.Code);
        }
    }
}
